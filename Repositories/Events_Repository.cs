using EventsApi.Services;
using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using EventsApi.Classes;
using EventsApi.Settings;

namespace EventsApi.Repositories
{
    public class Events_Repository : IEvents_Services
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<Events_Repository> _logger;
        private readonly HttpContext _httpContext;

        public Events_Repository(AppDbContext context, IMemoryCache memoryCache, 
            UserManager<IdentityUser> userManager, HttpContext httpContext, ILogger<Events_Repository> logger)
        {
            _context = context;
            _memoryCache = memoryCache;
            _userManager = userManager;
            _httpContext = httpContext;
            _logger = logger;
        }

        //retrieve all establlished Events.
        public async Task<List<Event>> GetAll(int pageNumber, CancellationToken Token)
        {
            int pageSize = Preferences.PageSize;
            string keyIdentifier = $"{pageNumber}Ev";
            try
            {
                if (!_memoryCache.TryGetValue(keyIdentifier, out List<Event>? result))
                {
                    result = await _context.Events.OrderBy(a => a.EventId).Where(a => a.EventId > (pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync(Token);
                    _memoryCache.Set(keyIdentifier, result, TimeSpan.FromMinutes(3600));
                }
                return (result != null) ? result : new List<Event>();
            }
            catch (Exception)
            {
                return new List<Event>();
            }
        }

        //Accept invite.
        public async Task<bool> AcceptInvitation(string Eventid, int participantId)
        {
            //get participant details then add the even if the event id doesnt exist yet.
            try
            {
                if (!_memoryCache.TryGetValue(participantId, out Participant? cachedPerson))
                {
                    cachedPerson = await _context.Participants.FindAsync(participantId);
                    // Cache the data for future requests
                    _memoryCache.Set(participantId, cachedPerson, TimeSpan.FromMinutes(3600));
                    if (cachedPerson != null && cachedPerson.BookedEvents.Contains(Eventid)) return false;
                    cachedPerson?.BookedEvents.Add(Eventid);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeclineInvitation(int Eventid, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                return true;
            }
            return false;
        }

        List<Event> IEvents_Services.CheckStatus(int Eventid)
        {
            throw new NotImplementedException();
            //Testing Commit
        }

        //send invite
        public async Task<bool> SendInvite(Mail request)
        {
            var userIdClaim = _httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
               throw new Exception("Unauthorized to access resource.");
            }
            var userId = userIdClaim.Value;
            try
            {
                string emailFrom = userIdClaim.ToString();
                string password = "*****";
                string smtpServer = "smtp.gmail.com";
                int port = 587;
                var message = new MailMessage(emailFrom, request.EmailTo);
                message.Subject = request.Subject;
                message.Body = request.Content;

                //SMTP client.
                using (var client = new SmtpClient(smtpServer, port))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(emailFrom, password);
                    await client.SendMailAsync(message);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}

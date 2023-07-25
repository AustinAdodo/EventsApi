using EventsApi.Services;
using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using EventsApi.Classes;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EventsApi.Repositories
{
    public class Events_Repository : IEvents_Services
    {
        private readonly AppDbContext _context;
        public bool AcceptInvitation(string Eventid, int participantId)
        {
            //get participant details then add the even if the event id doesnt exist yet.
            try
            {
                var person = _context.Participants.Where(a => a.id == participantId).First();
                if (person.BookedEvents.Contains(Eventid)) return false;
                person.BookedEvents.Add(Eventid); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeclineInvitation(int Eventid)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SendInvite(Mail request)
        {
            try
            {
                string emailFrom = "YourEmailAddress";
                string password = "YourEmailPassword";
                string smtpServer = "YourSMTPServer";
                int port = 587;
                var message = new MailMessage(emailFrom, request.EmailTo);
                message.Subject = "Your Subject";
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
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        List<Event> IEvents_Services.CheckStatus(int Eventid)
        {
            throw new NotImplementedException();
        }
    }
}

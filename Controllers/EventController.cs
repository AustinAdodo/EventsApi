using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using EventsApi.Classes;
using System.Text.Json;
using System.Net.WebSockets;
using EventsApi.Services;
using Microsoft.Extensions.Logging;

namespace EventsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEvents_Services _eventService;
        public EventController(IEvents_Services eventService)
        {
            _eventService = eventService;
        }

        //all
        [HttpGet()]
        public async Task<IActionResult> All([FromQuery]int pageNumber,CancellationToken token)
        {
            try
            {
                var result = await _eventService.GetAll(pageNumber,token);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //decline
        [HttpPost("/decline")]
        public IActionResult Decline([FromQuery] string Eventid, [FromQuery] int ParticipantId)
        {
            try
            {
                return Ok($"Individual with Id {ParticipantId} has Declined invitation of event with id {Eventid}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        //accept
        [HttpPost("/accept")]
        public async Task<IActionResult> Accept([FromQuery] string Eventid, [FromQuery] int ParticipantId)
        {
            try
            {
                await _eventService.AcceptInvitation(Eventid, ParticipantId);
                return Ok("Event Accepted");
            }
            catch (Exception ex)
            {
                return BadRequest($"Either events has been booked already by this person or person not found: {ex.Message}");
            }
        }

        //sendinvite
        [HttpPost("/send")]
        public async Task<IActionResult> SendInvite([FromBody] string request)
        {
            Mail? body = JsonSerializer.Deserialize<Mail>(request);
            try
            {
                await _eventService.SendInvite(body); return Ok($"Email sent successfully to {body.EmailTo}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to send the email: {ex.Message}");
            }
        }
    }
}

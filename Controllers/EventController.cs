using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using EventsApi.Classes;
using System.Text.Json;
using System.Net.WebSockets;
using EventsApi.Services;

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

        [HttpPost]
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

        [HttpPost]
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

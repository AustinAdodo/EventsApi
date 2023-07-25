using EventsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventsApi.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly IParticipants_Services _participant_Services;
        public ParticipantsController(IParticipants_Services participant_Services)
        {
            _participant_Services = participant_Services;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace EventsApi.Controllers
{
    public class ParticipantsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

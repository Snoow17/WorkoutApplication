using Microsoft.AspNetCore.Mvc;

namespace WorkoutApplication.Controllers
{
    public class WorkoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

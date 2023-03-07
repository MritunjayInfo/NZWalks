using Microsoft.AspNetCore.Mvc;

namespace NZWalksAPI.Controllers
{
    public class WalksDifficultyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

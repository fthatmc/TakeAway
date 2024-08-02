using Microsoft.AspNetCore.Mvc;

namespace TakeAway.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

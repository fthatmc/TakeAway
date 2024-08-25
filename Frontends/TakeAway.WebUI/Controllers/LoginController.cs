using Microsoft.AspNetCore.Mvc;

namespace TakeAway.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

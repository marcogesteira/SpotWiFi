using Microsoft.AspNetCore.Mvc;

namespace SpotiWiFi.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SpotiWiFi.Admin.Models;
using SpotiWiFi.Application.Admin;

namespace SpotiWiFi.Admin.Controllers
{
    public class AccountController : Controller
    {
        private UsuarioAdminService _usuarioAdminService;

        public AccountController(UsuarioAdminService usuarioAdminService)
        {
            _usuarioAdminService = usuarioAdminService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            return View();
        }
    }
}

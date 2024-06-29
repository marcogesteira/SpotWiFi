using Microsoft.AspNetCore.Mvc;
using SpotiWiFi.Application.Admin;

namespace SpotiWiFi.Admin.Controllers
{
    public class UserController : Controller
    {
        private UsuarioAdminService _usuarioAdminService;

        public UserController(UsuarioAdminService usuarioAdminService)
        {
            _usuarioAdminService = usuarioAdminService;
        }

        public IActionResult Index()
        {
            var result = this._usuarioAdminService.ObterTodos();
            return View(result);
        }
    }
}

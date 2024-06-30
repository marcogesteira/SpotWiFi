using Microsoft.AspNetCore.Mvc;
using SpotiWiFi.Application.Admin;
using SpotiWiFi.Application.Admin.Dto;

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

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(UsuarioAdminDto dto)
        {
            if (ModelState.IsValid == false) 
            {
                return View("Criar");
            }

            this._usuarioAdminService.Salvar(dto);
            
            return RedirectToAction("Index");
        }
    }
}

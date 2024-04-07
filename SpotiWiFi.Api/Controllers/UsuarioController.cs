using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotiWiFi.Api.Controllers.Request;
using SpotiWiFi.Application.Conta;
using SpotiWiFi.Application.Conta.Dto;

namespace SpotiWiFi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Criar(UsuarioDto dto)
        {
            if (ModelState is { IsValid: false})
                return BadRequest();

            var result = this._usuarioService.Criar(dto);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var result = this._usuarioService.Obter(id);

            if(result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            if (ModelState.IsValid == false)
                return BadRequest();
            
            var result = this._usuarioService.Autenticar(login.Email, login.Senha);

            if (result == null)
                return BadRequest(new
                {
                    Error = "Email ou senha inválidos"
                });
            return Ok(result);
        }
    }
}

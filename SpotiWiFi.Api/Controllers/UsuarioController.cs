using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotiWiFi.Api.Controllers.Request;
using SpotiWiFi.Application.Conta;
using SpotiWiFi.Application.Conta.Dto;

namespace SpotiWiFi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "spotiwifi-user")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = await this._usuarioService.Criar(dto);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var result = this._usuarioService.Obter(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var result = await this._usuarioService.Autenticar(login.Email, login.Senha);

            if (result == null)
                return BadRequest(new
                {
                    Error = "Email ou senha inválidos"
                });
            return Ok(result);
        }
        //[HttpGet("playlist/{id}")]
        //public IActionResult ObterPlaylist(Guid id)
        //{
        //    var result = this._usuarioService.ObterPlaylist(id);

        //    if (result == null)
        //        return NotFound();

        //    return Ok(result);
        //}
        //[HttpPost("playlist")]
        //public IActionResult AdicionarMusicaNaPlaylist([FromBody] string nome, Guid idPlaylist)
        //{
        //    if (ModelState is { IsValid: false })
        //        return BadRequest();

        //    var result = this._usuarioService.AdicionarMusicaNaPlaylist(nome, idPlaylist);

        //    return Ok(result);
        //}
    }
}

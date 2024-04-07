using System.ComponentModel.DataAnnotations;

namespace SpotiWiFi.Api.Controllers.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Campo Email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Senha é obrigat´rio")]
        public string Senha { get; set; }
    }
}

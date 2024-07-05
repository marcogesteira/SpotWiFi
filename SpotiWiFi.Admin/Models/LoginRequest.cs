using System.ComponentModel.DataAnnotations;

namespace SpotiWiFi.Admin.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo Email não está em um formato correto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public string Password { get; set; }

    }
}

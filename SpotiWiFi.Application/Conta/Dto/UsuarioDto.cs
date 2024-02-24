using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Conta.Request
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Senha { get; set; }
        [Required]
        public DateTime DtNascimento { get; set; }
        [Required]
        public String CPF { get; set; }
        [Required]
        public EnderecoCobrancaDto EnderecoCobranca { get; set; }

        public Guid PlanoId { get; set; }
        [Required]
        public CartaoDto Cartao { get; set; }
    }
}

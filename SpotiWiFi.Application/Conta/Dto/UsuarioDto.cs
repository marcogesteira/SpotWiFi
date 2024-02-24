using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Conta.Request
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public DateTime DtNascimento { get; set; }
        public String CPF { get; set; }
        public EnderecoCobrancaDto EnderecoCobranca { get; set; }

        public Guid PlanoId { get; set; }
        public CartaoDto Cartao { get; set; }
    }
}

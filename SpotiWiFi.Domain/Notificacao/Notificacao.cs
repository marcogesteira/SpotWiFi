using SpotiWiFi.Domain.Conta.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Notificacao
{
    public class Notificacao
    {
        public Guid Id { get; set; }
        public DateTime DtNotificacao { get; set; }
        public String Titulo { get; set; }
        public String Mensagem { get; set; }
        public Usuario UsuarioDestino { get; set; }
        public Usuario? UsuarioRemetente { get; set; }
        public TipoNotificacao TipoNotificacao { get; set; }

        public static Notificacao Criar(string titulo, string mensagem, TipoNotificacao tipoNotificacao, Usuario destino, Usuario remetente = null)
        {
            if (tipoNotificacao == TipoNotificacao.Usuario && remetente == null)
            {
                throw new ArgumentNullException("Para tipo de mensagem 'usuário' você deve informar quem foi o remetente");
            }
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new ArgumentNullException("Informe o título da notificação");
            }
            if (string.IsNullOrWhiteSpace(mensagem))
            {
                throw new ArgumentNullException("Informe a mensagem da notificação");
            }
            return new Notificacao();
        }
    }
    public enum TipoNotificacao
    {
        Usuario = 1,
        Sistema = 2
    }
}

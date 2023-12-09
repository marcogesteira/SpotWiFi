using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Conta.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiWiFi.Domain.Transacao.Aggregates;

namespace SpotiWiFi.Domain.Conta.Aggregates
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public DateTime DtNascimento { get; set; }
        public List<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public CPF CPF { get; set; }
        public EnderecoCobranca EnderecoCobranca { get; set; }
        public List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public Usuario() { }

        public void AdicionarPlaylist(Playlist playlist)
        {
            Playlists.Add(playlist);
        }
    }
}

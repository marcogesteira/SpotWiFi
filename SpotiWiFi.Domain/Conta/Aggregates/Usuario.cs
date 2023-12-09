using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Conta.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Conta.Aggregates
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public CPF CPF { get; set; }
        public EnderecoCobranca EnderecoCobranca { get; set; }
        public Plano Assinatura { get; set; }
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public Usuario() { }

        public void AdicionarPlaylist(Playlist playlist)
        {
            Playlists.Add(playlist);
        }
    }
}

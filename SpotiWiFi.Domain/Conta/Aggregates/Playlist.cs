using SpotiWiFi.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Conta.Aggregates
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public List<Musica> Musicas { get; set; } = new List<Musica>();

        public Playlist() { }


    }
}

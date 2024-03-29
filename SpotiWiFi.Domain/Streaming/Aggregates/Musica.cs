using SpotiWiFi.Domain.Conta.Aggregates;
using SpotiWiFi.Domain.Streaming.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Streaming.Aggregates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public Duracao Duracao { get; set; }

        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();

    }
}

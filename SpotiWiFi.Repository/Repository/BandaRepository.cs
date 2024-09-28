using Microsoft.Extensions.Configuration;
using SpotiWiFi.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Repository
{
    public class BandaRepository : CosmosDBContext
    {
        public SpotiWiFiContext Context { get; set; }

        public BandaRepository(IConfiguration configuration) : base(configuration)
        {
            this.SetContainer("banda");
        }

        public IEnumerable<Musica> GetMusicaByName(string name)
        {
            return this.Context.Musicas.Where(m => m.Nome.Contains(name)).ToList();
        }

        public Album GetAlbumById(Guid id)
        {
            return this.Context.Set<Album>().Find(id);
        }
    }
}

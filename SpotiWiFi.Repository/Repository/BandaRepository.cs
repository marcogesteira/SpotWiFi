using SpotiWiFi.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Repository
{
    public class BandaRepository : RepositoryBase<Banda>
    {
        public BandaRepository(SpotiWiFiContext context) : base(context)
        {


        }

        public IEnumerable<Musica> GetMusicaByName(string name)
        {
            return this.Context.Musicas.Where(m => m.Nome.Contains(name)).ToList();
        }
    }
}

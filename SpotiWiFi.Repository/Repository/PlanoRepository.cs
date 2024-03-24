using SpotiWiFi.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>
    {
        public SpotiWiFiContext Context { get; set; }

        public PlanoRepository(SpotiWiFiContext context) : base(context)
        {
            Context = context;
        }
    }
}

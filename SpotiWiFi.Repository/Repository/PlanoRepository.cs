using SpotiWiFi.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Repository
{
    public class PlanoRepository
    {
        public SpotiWiFiContext Context { get; set; }

        public PlanoRepository(SpotiWiFiContext context)
        {
            Context = context;
        }

        public Plano GetPlanoById(Guid id)
        {
            return this.Context.Planos.FirstOrDefault(p => p.Id == id);
        }
    }
}

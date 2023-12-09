using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Transacao.ValueObject
{
    public record Merchant
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
    }
}

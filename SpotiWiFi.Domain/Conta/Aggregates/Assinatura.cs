﻿using SpotiWiFi.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Conta.Aggregates
{
    public class Assinatura
    {
        public Guid Id { get; set; }
        public virtual Plano Plano { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime DtAtivacao { get; set; }
    }
}

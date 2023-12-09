using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Streaming.ValueObjects
{
    public record Monetario
    {
        public static implicit operator Decimal(Monetario d) => d.Valor;
        public static implicit operator Monetario(Decimal valor) => new Monetario(valor);


        public int Valor { get; set; }

        public Monetario(int valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor monetário não pode ser negativo");

            this.Valor = valor;
        }
        public String Formatado()
        {
            return $"R$ {this.Valor.ToString("N2")}";
        }
    }
}

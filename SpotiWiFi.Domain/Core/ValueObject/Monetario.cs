using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Core.ValueObject
{
    public record Monetario
    {
        public static implicit operator decimal(Monetario d) => d.Valor;
        public static implicit operator Monetario(decimal valor) => new Monetario(valor);


        public int Valor { get; set; }

        public Monetario(int valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor monetário não pode ser negativo");

            Valor = valor;
        }
        public string Formatado()
        {
            return $"R$ {Valor.ToString("N2")}";
        }
    }
}

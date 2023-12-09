using SpotiWiFi.Domain.Streaming.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Conta.ValueObjects
{
    public record CPF
    {
        public static implicit operator int(CPF d) => d.Valor;
        public static implicit operator CPF(int valor) => new CPF(valor);

        public int Valor { get; set; }

        public CPF(int valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Insira um CPF Válido");

            this.Valor = valor;
        }
        public String Formatado()
        {
            return $"{this.Valor.ToString()}";
        }
    }
}

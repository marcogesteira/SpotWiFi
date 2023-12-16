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
        public String Numero { get; set; }

        public CPF(string numero)
        {
            if (this.ValidaCPF(numero))
                throw new Exception("CPF Inválido");

            Numero = numero;
        }

        private bool ValidaCPF(string numero)
        {
            string[] numeros = new string[9];
            string[] digitos = new string[2];

            //Recortar números do CPF
            for (int i = 0; i < 9; i++)
            {
                numeros[i] = numero.Substring(i, 1);
            }

            //Recortar dígitos verificadores
            for (int i = 0; i < 2; i++)
            {
                digitos[i] = numero.Substring((i + 9), 1);
            }

            //Somatório dos 9 números
            int soma = 0;
            int fator = 10;
            for (int i = 0; i < 9; i++)
            {
                soma += (fator * int.Parse(numeros[i]));
                fator--;
            }
            //Cálculo do 1º dígito verificador
            int resto = soma % 11;
            int primeiroDigito = 11 - resto;
            if (primeiroDigito >= 10)
            {
                primeiroDigito = 0;
            }

            //Somatório dos 10 números
            soma = 0;
            fator = 11;
            for (int i = 0; i < 9; i++)
            {
                soma += (fator * int.Parse(numeros[i]));
                fator--;
            }
            soma += primeiroDigito * 2;
            //Cálculo do 2º dígito verificador
            resto = soma % 11;
            int segundoDigito = 11 - resto;
            if (segundoDigito >= 10)
            {
                segundoDigito = 0;
            }

            //Validação dos dígitos
            if (primeiroDigito == int.Parse(digitos[0]) && segundoDigito == int.Parse(digitos[1]))
            {
                return false;
            }
            else { return true; }
        }
    }
}

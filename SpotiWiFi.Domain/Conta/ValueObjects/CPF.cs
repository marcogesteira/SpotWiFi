﻿using SpotiWiFi.Domain.Streaming.ValueObjects;
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
            this.ValidaCPF(numero);

            Numero = numero;
        }

        public CPF()
        {
            
        }

        public void ValidaCPF(string numero)
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
            
            //Cálculo dos dígitos
            int primeiroDigito = this.CalculaPrimeiroDigito(numeros);
            int segundoDigito = this.CalculaSegundoDigito(numeros, primeiroDigito);

            //Validação dos dígitos
            if (primeiroDigito != int.Parse(digitos[0]) || segundoDigito != int.Parse(digitos[1]))
            {
                throw new Exception("CPF Inválido");
            }
        }
        private int CalculaPrimeiroDigito(string[] numeros)
        {
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
            return primeiroDigito;
        }
        private int CalculaSegundoDigito(string[] numeros, int primeiroDigito)
        {
            //Somatório dos 10 números
            int soma = 0;
            int fator = 11;
            for (int i = 0; i < 9; i++)
            {
                soma += (fator * int.Parse(numeros[i]));
                fator--;
            }
            soma += primeiroDigito * 2;
            //Cálculo do 2º dígito verificador
            int resto = soma % 11;
            int segundoDigito = 11 - resto;
            if (segundoDigito >= 10)
            {
                segundoDigito = 0;
            }
            return segundoDigito;
        }
    }
}

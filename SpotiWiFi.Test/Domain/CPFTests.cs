using SpotiWiFi.Domain.Conta.ValueObjects;
using SpotiWiFi.Domain.Transacao.Aggregates;
using SpotiWiFi.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Test.Domain
{
    public class CPFTests
    {
        [Fact]
        public void CpfValido()
        {
            CPF cpf = new CPF("93018630068");
            Assert.True(cpf.Numero == "93018630068");
        }
        [Fact]
        public void ValidaCPF_PrimeiroDigitoInvalido_DeveRetornarException()
        {
            //Arrays
            var cpfComPrimeiroNumeroInvalido = "93018630038";

            //Configs

            //Tests

            //Asserts
            CPF cpf = new CPF();
            Assert.Throws<System.Exception>(() => cpf.ValidaCPF(cpfComPrimeiroNumeroInvalido));
        }

        [Fact]
        public void ValidaCPF_SegundoDigitoInvalido_DeveRetornarException()
        {
            //Arrays
            var cpfComSegundoNumeroInvalido = "93018630065";

            //Configs

            //Tests

            //Asserts
            CPF cpf = new CPF();
            Assert.Throws<System.Exception>(() => cpf.ValidaCPF(cpfComSegundoNumeroInvalido));
        }
    }
}

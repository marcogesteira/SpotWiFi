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
        public void DeveCriarCPFComSucesso()
        {
            CPF cpf = new CPF("93018630068");
            Assert.True(cpf.Numero == "93018630068");
        }
        [Fact]
        public void ValidaCPF_PrimeiroDigitoInvalido_DeveRetornarException()
        {
            //Arrange
            var cpfComPrimeiroNumeroInvalido = "93018630038";

            //Act

            //Asserts
            CPF cpf = new CPF();
            Assert.Throws<System.Exception>(() => cpf.ValidaCPF(cpfComPrimeiroNumeroInvalido));
        }

        [Fact]
        public void ValidaCPF_SegundoDigitoInvalido_DeveRetornarException()
        {
            //Arrange
            var cpfComSegundoNumeroInvalido = "93018630065";

            //Act

            //Asserts
            CPF cpf = new CPF();
            Assert.Throws<System.Exception>(() => cpf.ValidaCPF(cpfComSegundoNumeroInvalido));
        }
    }
}

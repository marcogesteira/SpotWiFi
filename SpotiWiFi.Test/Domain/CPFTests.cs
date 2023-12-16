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
            CPF cpf = new CPF("12137346737");
            Assert.True(cpf.Numero == "12137346737");
        }
        //[Fact]
        //public void PrimeiroDigitoInvalido()
        //{
        //    CPF cpf = new CPF("12137346747");
        //    Assert.Throws<SystemException> () => cpf = new CPF("12137346747");
        //}
        //[Fact]
        //public void SegundoDigitoInvalido()
        //{
        //    CPF cpf = new CPF("12137346738");
        //    Assert.Throws<System.Exception>(
        //        () => 'CPF Inválido');
        //}
    }
}

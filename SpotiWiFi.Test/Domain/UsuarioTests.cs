using SpotiWiFi.Domain.Conta.Aggregates;
using SpotiWiFi.Domain.Conta.ValueObjects;
using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Test.Domain
{
    public class UsuarioTests
    {
        [Fact]
        public void DeveCriarUsuarioComSucesso()
        {
            //Arrange
            Plano plano = new Plano()
            {
                Descricao = "Descricao teste",
                Id = Guid.NewGuid(),
                Nome = "Plano teste",
                Valor = 24.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 2000M,
                Numero = "4050556219202522"
            };

            CPF cpf = new CPF() { Numero = "93018630068" };

            EnderecoCobranca enderecoCobranca = new EnderecoCobranca()
            {
                Id = Guid.NewGuid(),
                Endereco = "Rua das Couves, 30",
                Bairro = "Vale das Colinas",
                Cidade = "Jardim dos Girassóis",
                Pais = "Terra do Nunca",
                CEP = "24240-240"
            };

            string nome = "Usuario Teste";
            string email = "teste@teste.com.br";
            string senha = "password";

            //Act
            Usuario usuario = new Usuario();
            usuario.CriarConta(nome, email, senha, DateTime.Now, cpf, enderecoCobranca, plano, cartao);

            //Assert
            Assert.NotNull(usuario.Nome);
            Assert.NotNull(usuario.Email);
            Assert.NotNull(usuario.CPF);
            Assert.NotNull(usuario.EnderecoCobranca);
            Assert.True(usuario.Nome == nome);
            Assert.True(usuario.Email == email);
            Assert.True(usuario.Senha != senha);
            Assert.True(usuario.CPF == cpf);
            Assert.True(usuario.EnderecoCobranca == enderecoCobranca);

            Assert.True(usuario.Assinaturas.Count > 0);
            Assert.Same(usuario.Assinaturas[0].Plano, plano);

            Assert.True(usuario.Cartoes.Count > 0);
            Assert.Same(usuario.Cartoes[0], cartao);

            Assert.True(usuario.Playlists.Count > 0);
            Assert.True(usuario.Playlists[0].Nome == "Favoritas");
            Assert.False(usuario.Playlists[0].Publica);

        }
        [Fact]
        public void NaoDeveCriarUsuarioComCartaoSemLimite()
        {
            //Arrange
            Plano plano = new Plano()
            {
                Descricao = "Descricao teste",
                Id = Guid.NewGuid(),
                Nome = "Plano teste",
                Valor = 24.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 15M,
                Numero = "4050556219202522"
            };

            CPF cpf = new CPF() { Numero = "93018630068" };

            EnderecoCobranca enderecoCobranca = new EnderecoCobranca()
            {
                Id = Guid.NewGuid(),
                Endereco = "Rua das Couves, 30",
                Bairro = "Vale das Colinas",
                Cidade = "Jardim dos Girassóis",
                Pais = "Terra do Nunca",
                CEP = "24240-240"
            };

            string nome = "Usuario Teste";
            string email = "teste@teste.com.br";
            string senha = "password";

            //Act
            Assert.Throws<Exception>(() =>
            {
                Usuario usuario = new Usuario();
                usuario.CriarConta(nome, email, senha, DateTime.Now, cpf, enderecoCobranca, plano, cartao);
            });
        }
    }
}

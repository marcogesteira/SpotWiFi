using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Conta.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiWiFi.Domain.Transacao.Aggregates;
using SpotiWiFi.Domain.Transacao.ValueObject;
using SpotiWiFi.Domain.Core.ValueObject;
using System.Data;
using System.Security.Cryptography;
using SpotiWiFi.Domain.Core.Extension;

namespace SpotiWiFi.Domain.Conta.Aggregates
{
    public class Usuario
    {
        private const string NOME_PLAYLIST = "Favoritas";

        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public DateTime DtNascimento { get; set; }
        public virtual CPF CPF { get; set; }
        public virtual EnderecoCobranca EnderecoCobranca { get; set; }
        public virtual IList<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public virtual IList<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual IList<Notificacao.Notificacao> Notificacoes { get; set; } = new List<Notificacao.Notificacao>();

        public Usuario() { }

        public void CriarConta(string nome, string email, string senha, DateTime dtNascimento, CPF cpf, EnderecoCobranca enderecoCobranca, Plano plano, Cartao cartao)
        {
            this.Nome = nome;
            this.Email = email;
            this.DtNascimento = dtNascimento;
            this.CPF = cpf;
            this.EnderecoCobranca = enderecoCobranca;

            //Criptografar a senha
            this.Senha = this.CriptografarSenha(senha);

            //Assinar um plano
            this.AssinarPlano(plano, cartao);

            //Adicionar cartão na conta
            this.AdicionarCartao(cartao);

            //Criar a playlist padrão
            this.AdicionarPlaylist(nome: NOME_PLAYLIST, publica: false);
        }

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartão
            cartao.CriarTransacao(new Merchant() { Nome = plano.Nome }, new Monetario(plano.Valor), plano.Descricao);

            //Caso tenha alguma assinatura ativa, desativa ela
            DesativarAssinatura();

            //Adicionar assinatura
            this.Assinaturas.Add(new Assinatura()
            {
                Ativo = true,
                Plano = plano,
                DtAtivacao = DateTime.Now
            });
        }

        private void DesativarAssinatura()
        {
            if (this.Assinaturas.Count > 0 && this.Assinaturas.Any(x => x.Ativo))
            {
                var planoAtivo = this.Assinaturas.FirstOrDefault(x => x.Ativo);
                planoAtivo.Ativo = false;
            }
        }

        private void AdicionarCartao(Cartao cartao)
        {
            this.Cartoes.Add(cartao);
        }
        public void AdicionarPlaylist(string nome, bool publica = true)
        {
            this.Playlists.Add(new Playlist()
            {
                Nome = nome,
                Publica = publica,
                DtCriacao = DateTime.Now,
                Usuario = this
            });
        }
        private String CriptografarSenha(string senha)
        {
            return senha.HashSHA256();
        }
    }
}

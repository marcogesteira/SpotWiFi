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

namespace SpotiWiFi.Domain.Conta.Aggregates
{
    public class Usuario
    {
        

        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public DateTime DtNascimento { get; set; }
        public CPF CPF { get; set; }
        public EnderecoCobranca EnderecoCobranca { get; set; }
        public List<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public Usuario() { }

        public void CriarConta (string nome, string email, string senha,DateTime dtNascimento, CPF cpf, EnderecoCobranca enderecoCobranca, Plano plano, Cartao cartao)
        {
            this.Nome = nome;
            this.Email = email;
            this.EnderecoCobranca = enderecoCobranca;
            
            //Todo: Criptografar a senha
            this.Senha = senha;
            this.DtNascimento = dtNascimento;

            //Assinar um plano
            this.AssinarPlano(plano, cartao);
        }

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartão
            cartao.CriarTransacao(new Merchant() { Nome = plano.Nome }, new Monetario(plano.Valor), plano.Descricao);

            //Caso tenha alguma assinatura ativa, desativa ela
            //if (this.Assinaturas.Count > 0 && this.Assinaturas.Any(x => x.Ativo) 
            //{
            
            //}

        }

        public void AdicionarCartao(Cartao cartao)
        {
            this.Cartoes.Add(cartao);
        }
        public void AdicionarPlaylist(Playlist playlist)
        {
            Playlists.Add(playlist);
        }
    }
}

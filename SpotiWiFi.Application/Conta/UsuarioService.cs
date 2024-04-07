using AutoMapper;
using SpotiWiFi.Application.Conta.Dto;
using SpotiWiFi.Domain.Conta.Aggregates;
using SpotiWiFi.Domain.Conta.ValueObjects;
using SpotiWiFi.Domain.Core.Extension;
using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Transacao.Aggregates;
using SpotiWiFi.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Conta
{
    public class UsuarioService
    {
        private IMapper Mapper { get; set; }
        private UsuarioRepository UsuarioRepository { get; set; }
        private PlanoRepository PlanoRepository { get; set; }

        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository, PlanoRepository planoRepository)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
        }

        public UsuarioDto Criar(UsuarioDto dto)
        {
            if (this.UsuarioRepository.Exists(x => x.Email == dto.Email))
                throw new Exception("Usuário já existente na base");
            
            Plano plano = this.PlanoRepository.GetById(dto.PlanoId);

            if (plano == null) 
                throw new Exception("Plano não encontrado");

            Usuario usuario = new Usuario();

            Cartao cartao = this.Mapper.Map<Cartao>(dto.Cartao);
            CPF cpf = this.Mapper.Map<CPF>(dto.CPF);
            EnderecoCobranca enderecoCobranca = this.Mapper.Map<EnderecoCobranca>(dto.EnderecoCobranca);

            usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.DtNascimento, cpf, enderecoCobranca, plano, cartao);

            this.UsuarioRepository.Save(usuario);

            var result = this.Mapper.Map<UsuarioDto>(usuario);

            return result;
        }

        public UsuarioDto Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }

        public UsuarioDto Autenticar(string email, string senha)
        {
            var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == senha.HashSHA256()).FirstOrDefault();
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }
    }
}

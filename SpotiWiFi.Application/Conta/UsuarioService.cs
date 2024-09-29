using AutoMapper;
using SpotiWiFi.Application.Conta.Dto;
using SpotiWiFi.Application.Streaming.Dto;
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
        private BandaRepository BandaRepository { get; set; }
        private AzureServiceBusService ServiceBusService { get; set; }


        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository, PlanoRepository planoRepository, BandaRepository bandaRepository, AzureServiceBusService serviceBusService)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
            BandaRepository = bandaRepository;
            ServiceBusService = serviceBusService;
        }

        public async Task<UsuarioDto> Criar(UsuarioDto dto)
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

            //Notificar o usuário
            Notificacao notificacao = new Notificacao()
            {
                Mensagem = $"Seja bem-vindo ao SpotiWiFi, {usuario.Nome}",
                Nome = usuario.Nome,
                IdUsuario = usuario.Id
            };

            await this.ServiceBusService.SendMessage(notificacao);

            return result;
        }

        public UsuarioDto Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }

        public async Task<UsuarioDto> Autenticar(string email, string senha)
        {
            var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == senha.HashSHA256()).FirstOrDefault();
            var result = this.Mapper.Map<UsuarioDto>(usuario);

            //Notificar o usuário
            Notificacao notificacao = new Notificacao()
            {
                Mensagem = $"Alerta: {usuario.Nome} acabou de fazer login às {DateTime.Now}",
                Nome = usuario.Nome,
                IdUsuario = usuario.Id
            };

            await this.ServiceBusService.SendMessage(notificacao);

            return result;
        }

        //public PlaylistDto ObterPlaylist(Guid id)
        //{
        //    var playlist = this.UsuarioRepository.GetPlaylistById(id);
        //    var result = this.PlaylistParaPlaylistDto(playlist);
        //    return result;

        //}

        //public PlaylistDto AdicionarMusicaNaPlaylist(string nomeMusica, Guid idPlaylist)
        //{
        //    var musica = this.BandaRepository.GetMusicaByName(nomeMusica);
        //    if (musica == null)
        //        throw new Exception("Música não encontrada");
        //    var favorita = musica.FirstOrDefault();

        //    var playlist = this.UsuarioRepository.GetPlaylistById(idPlaylist);
        //    if (playlist == null)
        //        throw new Exception("Playlist não encontrada");

        //    playlist.AdicionarMusica(favorita);
            
        //    this.UsuarioRepository.UpdatePlaylist(playlist);

        //    var result = this.PlaylistParaPlaylistDto(playlist);

        //    return result;
 
        //}

        private PlaylistDto PlaylistParaPlaylistDto(Playlist playlist)
        {
            PlaylistDto dto = new PlaylistDto();
            dto.Id = playlist.Id;
            dto.Nome = playlist.Nome;
            dto.DtCriacao = playlist.DtCriacao;

            foreach (var item in playlist.Musicas)
            {
                var musicaDto = new MusicaDto()
                {
                    Id = item.Id,
                    Duracao = item.Duracao.Valor,
                    Nome = item.Nome
                };

                dto.Musicas.Add(musicaDto);
            }

            return dto;
        }
    }
}

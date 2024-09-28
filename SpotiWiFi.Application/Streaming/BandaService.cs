using AutoMapper;
using SpotiWiFi.Application.Streaming.Dto;
using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Streaming.ValueObjects;
using SpotiWiFi.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Streaming
{
    public class BandaService
    {
        private BandaRepository BandaRepository { get; set; }
        private IMapper Mapper { get; set; }


        public BandaService(BandaRepository bandaRepository, IMapper mapper)
        {
            BandaRepository = bandaRepository;
            Mapper = mapper;
        }

        public async Task<BandaDto> Criar(BandaDto dto)
        {
            Banda banda = this.Mapper.Map<Banda>(dto);

            await this.BandaRepository.SaveOrUpdate<Banda>(banda, banda.BandaKey);

            return this.Mapper.Map<BandaDto>(banda);
        }

        public async Task<BandaDto> Obter(Guid id)
        {
            var banda = await this.BandaRepository.ReadItem<Banda>(id.ToString());

            return this.Mapper.Map<BandaDto> (banda);
        }

        public async Task<IEnumerable<BandaDto>> Obter()
        {
            var banda = await this.BandaRepository.ReadAll<Banda>();

            return this.Mapper.Map<IEnumerable<BandaDto>>(banda);
        }

        public async Task<AlbumDto> AssociarAlbum(AlbumDto dto)
        {
            var banda = await this.BandaRepository.ReadItem<Banda>(dto.BandaId.ToString());

            if (banda == null)
                throw new Exception("Banda não encontrada");

            var novoAlbum = this.AlbumDtoParaAlbum(dto);

            banda.AdicionarAlbum(novoAlbum);

            await this.BandaRepository.SaveOrUpdate<Banda>(banda, banda.BandaKey);

            var result = this.AlbumParaAlbumDto(novoAlbum);

            return result;
        }

        public async Task<AlbumDto> ObterAlbumPorId(Guid idBanda, Guid id)
        {
            var banda = await this.BandaRepository.ReadItem<Banda>(idBanda.ToString());

            if (banda == null)
                throw new Exception("Banda não encontrada");

            var album = banda.Albums.FirstOrDefault(x => x.Id == id);

            var result = AlbumParaAlbumDto(album);
            result.BandaId = idBanda;

            return result;
        }

        public async Task<List<AlbumDto>> ObterAlbum(Guid idBanda)
        {
            var banda = await this.BandaRepository.ReadItem<Banda>(idBanda.ToString());

            if (banda == null)
                throw new Exception("Banda não encontrada");

            var result = new List<AlbumDto>();

            foreach (var item in banda.Albums)
            {
                result.Add(AlbumParaAlbumDto(item));
            }

            return result;
        }

        public async Task<MusicaDto> AssociarMusica(Guid idBanda, Guid idAlbum, MusicaDto dto)
        {
            var banda = await this.BandaRepository.ReadItem<Banda>(idBanda.ToString());
            var album = this.BandaRepository.GetAlbumById(idAlbum);

            if (album == null)
                throw new Exception("Album não encontrado");

            var novaMusica = new Musica
            {
                Nome = dto.Nome,
                Duracao = dto.Duracao
            };

            album.AdicionarMusica(novaMusica);

            this.BandaRepository.SaveOrUpdate<Banda>(banda, banda.BandaKey);

            var result = this.MusicaParaMusicaDto(novaMusica);
            return result;
        }
        
        public List<MusicaDto> BuscarMusica(string nomeMusica)
        {
            var musicas = this.BandaRepository.GetMusicaByName(nomeMusica);

            if (musicas == null)
                throw new Exception("Música não encontrada");

            var result = new List<MusicaDto>();
            foreach (var item in musicas)
                result.Add(MusicaParaMusicaDto(item));

            return (List<MusicaDto>)result;
        }

        private Album AlbumDtoParaAlbum(AlbumDto dto)
        {
            Album album = new Album()
            {
                Id = dto.Id,
                Nome = dto.Nome
            };

            foreach (MusicaDto item in dto.Musicas)
            {
                album.AdicionarMusica(new Musica
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Duracao = new Duracao(item.Duracao),
                });
            }

            return album;
        }

        private AlbumDto AlbumParaAlbumDto(Album album)
        {
            AlbumDto dto = new AlbumDto();
            
            dto.Id = album.Id;
            dto.Nome = album.Nome;

            foreach (var item in album.Musica)
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

        private MusicaDto MusicaParaMusicaDto(Musica musica)
        {
            MusicaDto dto = new MusicaDto();

            dto.Id = musica.Id;
            dto.Nome = musica.Nome;
            dto.Duracao = musica.Duracao.Valor;

            return dto;
        }

    }
}

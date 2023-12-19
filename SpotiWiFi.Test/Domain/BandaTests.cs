using SpotiWiFi.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Test.Domain
{
    public class BandaTests
    {
        [Fact]
        public void DeveCriarBandaComSucesso()
        {
            //Arrange
            Musica musica = new Musica()
            {
                Id = Guid.NewGuid(),
                Nome = "Musica teste",
                Duracao = 120,
            };

            Album album = new Album()
            {
                Id = Guid.NewGuid(),
                Nome = "Album teste",
            };
            Banda banda = new Banda()
            {
                Id = Guid.NewGuid(),
                Nome = "Banda teste",
                Descricao = "Descrição teste",
                Backdrop = "Backdrop teste"
            };

            //Act
            album.AdicionarMusica(musica);
            banda.AdicionarAlbum(album);

            //Assert
            Assert.NotNull(banda.Nome);
            Assert.NotNull(banda.Descricao);
            Assert.NotNull(banda.Backdrop);

            Assert.True(banda.Albums.Count > 0);
            Assert.Same(banda.Albums[0], album);
            Assert.True(album.Musica.Count > 0);
            Assert.Same(album.Musica[0], musica);
        }
        [Fact]
        public void NaoDeveCriarBandaComMusicaNegativa()
        {
            //Arrange
            Album album = new Album()
            {
                Id = Guid.NewGuid(),
                Nome = "Album teste",
            };
            Banda banda = new Banda()
            {
                Id = Guid.NewGuid(),
                Nome = "Banda teste",
                Descricao = "Descrição teste",
                Backdrop = "Backdrop teste"
            };
            Musica musica = new Musica();

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                album.AdicionarMusica(musica = new Musica()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Musica teste",
                    Duracao = -120
                });
            });
        }
    }
}

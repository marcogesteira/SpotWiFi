using SpotiWiFi.Application.Streaming.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Conta.Dto
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public List<MusicaDto> Musicas { get; set; } = new List<MusicaDto>();
        public DateTime DtCriacao { get; set; }
    }
}

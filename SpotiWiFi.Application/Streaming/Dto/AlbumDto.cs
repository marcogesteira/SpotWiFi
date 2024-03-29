﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Streaming.Dto
{
    public class AlbumDto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid BandaId { get; set; }
        [Required]
        public string Nome {  get; set; }
        public List<MusicaDto> Musicas { get; set; } = new List<MusicaDto>();
    }

    public class MusicaDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public int Duracao { get; set; }
    }
}

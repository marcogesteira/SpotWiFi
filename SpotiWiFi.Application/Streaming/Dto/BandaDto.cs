﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Streaming.Dto
{
    public class BandaDto
    {
        public Guid Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Descricao { get; set; }
        public String Backdrop { get; set; }
    }
}

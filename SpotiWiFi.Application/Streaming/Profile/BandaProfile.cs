using SpotiWiFi.Application.Streaming.Dto;
using SpotiWiFi.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Streaming.Profile
{
    public class BandaProfile : AutoMapper.Profile
    {
        public BandaProfile() 
        {
            CreateMap<BandaDto, Banda>()
                .ReverseMap();
        }
    }
}

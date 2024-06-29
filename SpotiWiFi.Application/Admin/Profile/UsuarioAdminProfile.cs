using SpotiWiFi.Application.Admin.Dto;
using SpotiWiFi.Domain.Admin.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Admin.Profile
{
    public class UsuarioAdminProfile : AutoMapper.Profile
    {
        public UsuarioAdminProfile() 
        {
            CreateMap<UsuarioAdminDto, UsuarioAdmin>()
                .ForMember(x => x.Perfil, m => m.MapFrom(f => (Perfil)f.Perfil))
                .ReverseMap();
        }
    }
}

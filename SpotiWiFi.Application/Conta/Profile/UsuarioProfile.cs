using SpotiWiFi.Application.Conta.Dto;
using SpotiWiFi.Domain.Conta.Aggregates;
using SpotiWiFi.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Conta.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ForPath(x => x.CPF.Numero, m => m.MapFrom(f => f.CPF))
                .ReverseMap();

            CreateMap<CartaoDto, Cartao>()
                .ForPath(x => x.Limite.Valor, m => m.MapFrom(f => f.Limite))
                .ReverseMap();
            
            CreateMap<EnderecoCobrancaDto, EnderecoCobranca>()
                .ReverseMap();
            
        }
    }
}

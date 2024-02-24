using SpotiWiFi.Application.Conta.Request;
using SpotiWiFi.Domain.Conta.Aggregates;
using SpotiWiFi.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Conta.Profile
{
    internal class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(x => x.CPF.Numero, m => m.MapFrom(f => f.CPF));
            CreateMap<Usuario, UsuarioDto>();

            CreateMap<CartaoDto, Cartao>()
                .ForMember(x => x.Limite.Valor, m => m.MapFrom(f => f.Limite));
            CreateMap<Cartao, CartaoDto>();

            CreateMap<EnderecoCobrancaDto, EnderecoCobranca>();
            CreateMap<EnderecoCobranca, EnderecoCobrancaDto>();
        }
    }
}

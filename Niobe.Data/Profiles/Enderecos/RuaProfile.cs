using AutoMapper;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niobe.Data
{
    public class RuaProfile : Profile
    {
        public RuaProfile()
        {
            CreateMap<CreateRuaDTO, Rua>();
            CreateMap<Rua, ReadRuaDTO>()
                .ForMember(rua => rua.Armazem, opts => opts
                .MapFrom(rua => new { rua.Armazem.Id, rua.Armazem.Codigo, rua.Armazem.Nome }));
        }
    }
}

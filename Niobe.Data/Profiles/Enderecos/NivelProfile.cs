using AutoMapper;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niobe.Data
{
    public class NivelProfile : Profile
    {
        public NivelProfile()
        {
            CreateMap<CreateNivelDTO, Nivel>();
            CreateMap<Nivel, ReadNivelDTO>()
                .ForMember(nivel => nivel.Coluna, opts => opts
                .MapFrom(nivel => new { nivel.Coluna.Id, nivel.Coluna.Codigo, nivel.Coluna.Nome }));

        }
    }
}

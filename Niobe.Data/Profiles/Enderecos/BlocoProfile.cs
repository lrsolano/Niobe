using AutoMapper;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niobe.Data
{
    public class BlocoProfile : Profile
    {
        public BlocoProfile()
        {
            CreateMap<CreateBlocoDTO, Bloco>();
            CreateMap<Bloco, ReadBlocoDTO>()
                .ForMember(bloco => bloco.Nivel, opts => opts
                .MapFrom(bloco => new { bloco.Nivel.Id, bloco.Nivel.Codigo, bloco.Nivel.Nome }));
        }
    }
}

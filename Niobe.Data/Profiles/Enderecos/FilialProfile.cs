using AutoMapper;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niobe.Data
{
    class FilialProfile : Profile
    {
        public FilialProfile()
        {
            CreateMap<CreateFilialDTO, Filial>();
            CreateMap<Filial, ReadFilialDTO>()
                .ForMember(filial => filial.Armazens, opts => opts
                .MapFrom(filial => filial.Armazens.Select
                (a => new { a.Id, a.Codigo, a.Nome})));
        }
    }
}

using AutoMapper;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Data.Profiles
{
    public class ArmazemProfile : Profile
    {
        public ArmazemProfile()
        {
            CreateMap<CreateArmazemDTO, Armazem>();
            CreateMap<Armazem, ReadArmazemDTO>()
                .ForMember(armazem => armazem.Filial, opts => opts
                .MapFrom(armazem => new { armazem.Filial.Id, armazem.Filial.Codigo, armazem.Filial.Nome }));
        }
    }
}

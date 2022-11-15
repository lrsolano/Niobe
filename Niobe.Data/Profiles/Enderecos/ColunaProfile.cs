using AutoMapper;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niobe.Data
{
    public class ColunaProfile : Profile
    {
        public ColunaProfile()
        {
            CreateMap<CreateColunaDTO, Coluna>();
            CreateMap<Coluna, ReadColunaDTO>()
                .ForMember(coluna => coluna.Rua, opts => opts
                .MapFrom(coluna => new { coluna.Rua.Id, coluna.Rua.Codigo, coluna.Rua.Nome }));

        }
    }
}

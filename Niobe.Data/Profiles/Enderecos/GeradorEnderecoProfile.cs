using AutoMapper;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Data
{
    public class GeradorEnderecoProfile : Profile
    {
        public GeradorEnderecoProfile()
        {
            CreateMap<CreateGeradorEnderecoDTO, GeradorEnderecos>();
            CreateMap<GeradorEnderecos, ReadGeradorEnderecoDTO>();
        }
    }
}

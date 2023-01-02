using AutoMapper;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Data
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile() 
        {
            CreateMap<CommomCreateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
        }
    }
}

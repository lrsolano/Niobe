using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Data
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}

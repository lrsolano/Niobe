using FluentResults;
using Niobe.Data;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Niobe.Service
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createUsuarioDto);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);

            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(usuarioIdentity, createUsuarioDto.Password);

            _userManager.AddToRoleAsync(usuarioIdentity, "regular");

            if (resultIdentity.Result.Succeeded) return Result.Ok();

            return Result.Fail("Falha ao cadastrar usuário");

        }
    }
}

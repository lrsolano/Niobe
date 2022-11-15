using FluentResults;
using Microsoft.AspNetCore.Identity;
using Niobe.Data;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Niobe.Service
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signManager, TokenService tokenService)
        {
            _signManager = signManager;
            _tokenService = tokenService;
        }

        public Token LoginUsuario(LoginRequest request)
        {
            var resutltadoIdentity = _signManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resutltadoIdentity.Result.Succeeded)
            {
                var identityUser = _signManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario => usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);

                return token;
            }
            return null;
        }
    }
}

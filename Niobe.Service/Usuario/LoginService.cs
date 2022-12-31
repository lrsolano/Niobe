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
        private SignInManager<CustomIdentityUser> _signManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signManager, TokenService tokenService)
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
                Token token = _tokenService.CreateToken(identityUser, _signManager.UserManager.GetRolesAsync(identityUser).Result);

                return token;
            }
            return null;
        }

        public string ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);
            IdentityResult identityResult = _signManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (identityResult.Succeeded) return "Senha Redefinnida com sucesso";

            return string.Empty;


        }


        public string SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            if (identityUser != null)
            {
                string codigoDeRecuperacao = _signManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return codigoDeRecuperacao;
            }
            return string.Empty;
        }
        private CustomIdentityUser RecuperaUsuarioPorEmail(string email)
        {
            return _signManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}

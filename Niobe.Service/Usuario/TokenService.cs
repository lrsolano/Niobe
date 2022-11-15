using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Niobe.Service
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> usuario)
        {
            long duracaoSegundosToken = 3600;

            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("70wxjgdl3rkz05ut4jmbum9wid60d8j0j2i2mz5tt1gs2xgdjb20xa36r0nitbko")
                );
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddSeconds(duracaoSegundosToken)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString, duracaoSegundosToken, "Bearer");
        }
    }
}

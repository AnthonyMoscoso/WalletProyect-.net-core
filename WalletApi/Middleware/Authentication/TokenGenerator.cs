using Entities.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WalletApi.Middleware.Authentication
{
    public class TokenGenerator
    {
        public static string GenerateJSONWebToken(IConfiguration configuration,UserDto user)
        {
            SymmetricSecurityKey _symmetricSecurityKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
              );
            SigningCredentials _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
         JwtHeader _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            Claim[] _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.IdUser.ToString()),
                new Claim("Name", user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            // CREAMOS EL PAYLOAD //
           JwtPayload _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(7)
                );
       
            // GENERAMOS EL TOKEN //
            JwtSecurityToken _Token = new JwtSecurityToken(  
                    _Header,
                    _Payload
                );
 

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}

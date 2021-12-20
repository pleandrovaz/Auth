using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth.Models;
using Auth.Properties;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Services
{
    public static class TokenService
    {
        /// <summary>
        /// somente receber o usuario e gerar um Role
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GenerateToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

           var token =   tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

    }
}

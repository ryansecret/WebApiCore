using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NDaisy.Core.ServiceLocator;

namespace WebApiCore.Utility
{
    public class Jwt
    {
        private static SecurityKey _signKey;
        private static IConfigurationSection _config;
        private const string Issue = "webcore";
        static Jwt()
        {
            _config= ServiceLocator.Current.GetInstance<IConfigurationRoot>().GetSection("Jwt");
            var keyAsBytes = Encoding.ASCII.GetBytes(_config.GetValue<string>("Salt"));
            _signKey = new SymmetricSecurityKey(keyAsBytes);
              
        }

        public static JwtBearerOptions GetJwtOptions()
        {
            return new JwtBearerOptions
            {
                TokenValidationParameters =
                {
                    ValidIssuer = Issue,
                    IssuerSigningKey = _signKey,
                    ValidateLifetime = true,
                    ValidateIssuer = true
                }
            };
        }

        public static string SignToken(IList<Claim> claims)
        {
            var seconds= _config.GetValue<int>("SlideTime");
             
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: Issue, claims: claims, expires: DateTime.UtcNow.AddSeconds(seconds), signingCredentials: new SigningCredentials(_signKey, SecurityAlgorithms.HmacSha256));
             
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }

}
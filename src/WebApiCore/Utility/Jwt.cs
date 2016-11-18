using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NDaisy.Core.ServiceLocator;
using WebApiCore.Core.Utility.Extension;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

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
                    ValidateIssuer = true,
                    ValidateAudience = false
                },
                  Events = new JwtBearerEvents()
                  {
                      OnAuthenticationFailed = c =>
                      {
                          
                          return Task.Run(() =>
                          {
                              if (ServiceLocator.Current.GetInstance<IHostingEnvironment>().IsDevelopment())
                              {
                                  c.Request.GetDisplayUrl().LogInfo();
                                  c.Exception.LogError();
                              }

                          } );
                      }
                   
                  }
            };
        }

        public static string SignToken(IList<Claim> claims)
        {
            var seconds= _config.GetValue<int>("SlideTime");
             
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: Issue, claims: claims, expires: DateTime.UtcNow.AddHours(24), signingCredentials: new SigningCredentials(_signKey, SecurityAlgorithms.HmacSha256));
             
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }

}
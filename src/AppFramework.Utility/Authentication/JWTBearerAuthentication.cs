using AppFramework.Domain.ViewModel.ModelInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppFramework.Utility
{
    public class JWTBearerAuthentication
    {
        private IConfiguration _configuration;

        public JWTBearerAuthentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// GenerateJSONWebToken
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userId"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static string GenerateJSONWebToken(string email, string userId, string userType,IConfiguration configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {

                new Claim(JwtRegisteredClaimNames.FamilyName,email),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("UserID", userId),
                new Claim("UserType",userType),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                        configuration["Jwt:Issuer"],
                        claims,
                        expires: DateTime.Now.AddMinutes(2000),
                        signingCredentials: credentials);
            string generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return generatedToken;
        }
    }
}



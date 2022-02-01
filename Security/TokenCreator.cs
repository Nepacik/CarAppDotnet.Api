using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using CarAppDotNetApi.ErrorHandling;
using CarAppDotNetApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CarAppDotNetApi.Security
{
    public class TokenCreator
    {
        private readonly SymmetricSecurityKey SecurityKey;
        
        public TokenCreator(IConfiguration configuration)
        {
            SecurityKey = configuration.GetTokenSecurityKey();
        }
        public string createToken(bool isAccessToken, User user)
        {
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            String role = user.Username.StartsWith("N") ? Role.Admin : Role.User;

            DateTime expirationDate = isAccessToken ? DateTime.Now.AddMinutes(5) : DateTime.Now.AddMonths(12);

            var tokenHander = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, role),
                }),
                Expires = expirationDate,
                SigningCredentials = credentials
            };
            var token = tokenHander.CreateToken(tokenDescriptor);
            return tokenHander.WriteToken(token);
        }

        public string ValidTokenAndGetUsername(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenParams(SecurityKey), out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken) validatedToken;
                var userName = jwtToken.Claims.First(x => x.Type == "unique_name").Value;

                if (userName == null)
                {
                    throw new AppException(HttpStatusCode.Unauthorized, "Authorization fail");
                }
                
                return userName;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw new AppException(HttpStatusCode.Unauthorized, "Authorization fail");
            }
        }
    }
}
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CarAppDotNetApi.Security
{
    public static class ConfigurationParams
    {
        public static SymmetricSecurityKey GetTokenSecurityKey(this IConfiguration configuration)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        }
    }
}
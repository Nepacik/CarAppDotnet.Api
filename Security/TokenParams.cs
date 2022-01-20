using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace CarAppDotNetApi.Security
{
    public class TokenParams : TokenValidationParameters
    {
        public TokenParams(IConfiguration configuration)
        {
            SetBaseParams();
            IssuerSigningKey = configuration.GetTokenSecurityKey();
        }
        public TokenParams(SymmetricSecurityKey securityKey)
        {
            SetBaseParams();
            IssuerSigningKey = securityKey;
        }

        private void SetBaseParams()
        {
            ValidateIssuer = false;
            ValidateAudience = false;
            ValidateLifetime = true;
            ValidateIssuerSigningKey = true;
        }
    }
}
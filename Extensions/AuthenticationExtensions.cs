using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarAppDotNetApi.Repositories;
using CarAppDotNetApi.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarAppDotNetApi.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddCarAppAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtOptions =>
                {
                    jwtOptions.TokenValidationParameters = new TokenParams(configuration);
                    jwtOptions.Events = new JwtBearerEvents()
                    {
                        OnTokenValidated = context =>
                        {
                            var userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>();
                            if (context.Principal == null)
                            {
                                context.Fail("Failed to authenticate");
                                return Task.CompletedTask;
                            }
                            var userName = context.Principal.Claims.First(x => x.Type == ClaimTypes.Name).Value;
                            if (userRepository != null && userRepository.GetUserByUserName(userName) == null)
                            {
                                context.Fail("Failed to authenticate");
                                return Task.CompletedTask;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            return services;
        }
    }
}
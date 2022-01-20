using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CarAppDotNetApi.Filters
{
    public class AuthorizeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var methodHasAuthorizeAttribute = context.MethodInfo
                .GetCustomAttributes(typeof(AuthorizeAttribute), true)
                .Any();

            var controllerHasAuthorizeAttribute = context.MethodInfo.DeclaringType
                .GetCustomAttributes(typeof(AuthorizeAttribute), true)
                .Any();

            if (methodHasAuthorizeAttribute || controllerHasAuthorizeAttribute)
            {
                if (operation.Security == null)
                    operation.Security = new List<OpenApiSecurityRequirement>();


                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    [scheme] = new List<string>()
                });
            }

        }

    }
}
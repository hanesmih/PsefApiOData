using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Swagger UI authorization filter.
    /// </summary>
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Swagger UI authorization filter.
        /// </summary>
        /// <param name="options">Api Security Options.</param>
        public AuthorizeCheckOperationFilter(IOptions<ApiSecurityOptions> options)
        {
            _options = options;
        }

        /// <summary>
        /// Apply filter.
        /// </summary>
        /// <param name="operation">Open Api operation.</param>
        /// <param name="context">Operation context.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize = context.MethodInfo.DeclaringType != null
                && !context.MethodInfo
                    .GetCustomAttributes(true)
                    .OfType<AllowAnonymousAttribute>()
                    .Any()
                && (context.MethodInfo.DeclaringType
                    .GetCustomAttributes(true)
                    .OfType<AuthorizeAttribute>()
                    .Any()
                || context.MethodInfo
                    .GetCustomAttributes(true)
                    .OfType<AuthorizeAttribute>()
                    .Any());

            if (hasAuthorize)
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });
                operation.Security.Add(ConfigureSecurityRequirement(_options.Value));
            }
        }

        private static OpenApiSecurityRequirement ConfigureSecurityRequirement(ApiSecurityOptions options)
        {
            if (_requirement == null)
            {
                _requirement = new OpenApiSecurityRequirement
                {
                    {
                        _scheme,
                        new[]
                        {
                            options.Audience
                        }
                    }
                };
            }

            return _requirement;
        }

        private static OpenApiSecurityRequirement _requirement;
        private readonly static OpenApiSecurityScheme _scheme = new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = ApiInfo.SchemeOauth2
            }
        };
        private readonly IOptions<ApiSecurityOptions> _options;
    }
}
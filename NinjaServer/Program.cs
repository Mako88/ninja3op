using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Logging;
using NinjaServer.Auth;

namespace NinjaServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IdentityModelEventSource.ShowPII = true;

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<JsonWebTokenHandler>();
            builder.Services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(async options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = await JwtTokenHandler.GetTokenValidationParameters();
            });

            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapGet("/test", () =>
            {
                return "hi";
            });

            MapEndpoints(app);

            app.Run();
        }

        private static void MapEndpoints(WebApplication app)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var endpointClasses = assemblies.Distinct().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEndpoint).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var endpoint in endpointClasses)
            {
                var instance = Activator.CreateInstance(endpoint) as IEndpoint;
                instance?.MapEndpoint(app);
            }
        }
    }
}

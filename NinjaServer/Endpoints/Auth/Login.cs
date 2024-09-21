
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaServer.Auth;

namespace NinjaServer.Endpoints.Auth
{
    public class Login : IEndpoint
    {
        public void MapEndpoint(WebApplication app) => app.MapPost("/auth/login", [AllowAnonymous] async (LoginRequest request, [FromServices] IJwtTokenHandler tokenHandler) =>
        {
            // TODO: Validate user exists/password is correct

            var refreshToken = tokenHandler.CreateRefreshToken();

            var accessToken = await tokenHandler.CreateToken("12");

            return new
            {
                accessToken,
                refreshToken,
            };
        });
    }

    public class LoginRequest
    {
        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}

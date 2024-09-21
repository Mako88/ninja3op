using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaServer.Auth;

namespace NinjaServer.Endpoints.Auth
{
    public class RefreshTokens : IEndpoint
    {
        public void MapEndpoint(WebApplication app) => app.MapPost("/auth/refresh", [AllowAnonymous] async (
            RefreshTokensRequest request,
            [FromHeader(Name = "Authorization")] string authHeader,
            [FromServices] IJwtTokenHandler tokenHandler) =>
        {
            var token = authHeader.Replace("Bearer ", "");

            var result = await tokenHandler.ValidateToken(token, false);

            return result.IsValid;
        });
    }

    public class RefreshTokensRequest
    {
        public required string RefreshToken { get; set; }
    }
}

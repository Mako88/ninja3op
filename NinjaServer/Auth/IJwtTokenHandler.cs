
using Microsoft.IdentityModel.Tokens;

namespace NinjaServer.Auth
{
    public interface IJwtTokenHandler
    {
        /// <summary>
        /// Create a JWT token for the given UserId
        /// </summary>
        Task<string> CreateToken(string userId);

        /// <summary>
        /// Generate a refresh token and save it to the databaes
        /// </summary>
        string CreateRefreshToken();

        /// <summary>
        /// Validate the given token
        /// </summary>
        Task<TokenValidationResult> ValidateToken(string token, bool validateLifetime = true);
    }
}
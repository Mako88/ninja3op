using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ScottBrady.IdentityModel.Crypto;
using ScottBrady.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace NinjaServer.Auth
{
    /// <summary>
    /// Class for JWT creation
    /// </summary>
    public class JwtTokenHandler : IJwtTokenHandler
    {
        private readonly JsonWebTokenHandler tokenHandler;

        /// <summary>
        /// Constructor
        /// </summary>
        public JwtTokenHandler(JsonWebTokenHandler tokenHandler)
        {
            this.tokenHandler = tokenHandler;
        }

        /// <summary>
        /// Create a JWT token for the given UserId
        /// </summary>
        public async Task<string> CreateToken(string userId)
        {
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(-1),
                SigningCredentials = await GetJwtSigningCredentials(),
                Audience = TokenConfiguration.Audience,
                Issuer = TokenConfiguration.Issuer,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Claims = new Dictionary<string, object>
                {
                    { "sub", userId }
                },
            });

            return token;
        }

        /// <summary>
        /// Generate a refresh token and save it to the databaes
        /// </summary>
        public string CreateRefreshToken()
        {
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }

            // TODO: Save the token to the database
        }

        /// <summary>
        /// Validate the given token
        /// </summary>
        public async Task<TokenValidationResult> ValidateToken(string token, bool validateLifetime = true)
        {
            var validationParams = await GetTokenValidationParameters(validateLifetime);

            return await tokenHandler.ValidateTokenAsync(token, validationParams);
        }

        /// <summary>
        /// Get the parameters for validating JWT tokens
        /// </summary>
        public static async Task<TokenValidationParameters> GetTokenValidationParameters(bool validateLifetime = true) => new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = TokenConfiguration.Audience,
            ValidateIssuer = true,
            ValidIssuer = TokenConfiguration.Issuer,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = await GetJwtKey(),
            ValidateLifetime = validateLifetime,
            ClockSkew = TimeSpan.Zero,


        };

        /// <summary>
        /// Get the security key for signing or validating JWT tokens
        /// </summary>
        private static async Task<EdDsaSecurityKey> GetJwtKey()
        {
            var signingKeyBytes = await File.ReadAllBytesAsync(EnvironmentConfig.JwtSigningKeyPath);

            if (signingKeyBytes.Length == 0)
            {
                throw new FileNotFoundException("Unable to read token signing key file");
            }

            var validationKeyBytes = await File.ReadAllBytesAsync(EnvironmentConfig.JwtValidationKeyPath);

            if (validationKeyBytes.Length == 0)
            {
                throw new FileNotFoundException("Unable to read token validation key file");
            }

            var eddsa = EdDsa.Create(new EdDsaParameters(ExtendedSecurityAlgorithms.Curves.Ed25519)
            {
                D = signingKeyBytes.TakeLast(32).ToArray(),
                X = validationKeyBytes.TakeLast(32).ToArray(),
            });

            return new EdDsaSecurityKey(eddsa);
        }

        /// <summary>
        /// Get the signing credentials for signing JWT tokens
        /// </summary>
        private static async Task<SigningCredentials> GetJwtSigningCredentials()
        {
            var signingKey = await GetJwtKey();

            return new SigningCredentials(signingKey, ExtendedSecurityAlgorithms.EdDsa);
        }
    }
}

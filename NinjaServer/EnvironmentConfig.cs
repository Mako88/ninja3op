namespace NinjaServer
{
    public static class EnvironmentConfig
    {
        public static string JwtSigningKeyPath => GetEnvironmentVariable("JWT_SIGNING_KEY_PATH", @"E:\Documents\SSH\jwt-private.der");

        public static string JwtValidationKeyPath => GetEnvironmentVariable("JWT_VALIDATION_KEY_PATH", @"E:\Documents\SSH\jwt-public.der");

        private static string GetEnvironmentVariable(string key, string defaultValue)
        {
            var value = Environment.GetEnvironmentVariable(key);

            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            return value;
        }
    }
}

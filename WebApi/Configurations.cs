namespace WebApi
{
    public static class Configurations
    {
        // ApiKey SendGrid = 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
        public static string JwtKey = "ZmVkYWY3ZDg4NjNiNDhlMTkyODdkyYjcwOGU=";
        public static string ApiKeyName = "api_key";
        public static string ApiKey = "admin_bot_api_IlTevUM/z0ey3NwCV/unWg==";
        public static SmtpConfiguration Smtp = new();

        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}

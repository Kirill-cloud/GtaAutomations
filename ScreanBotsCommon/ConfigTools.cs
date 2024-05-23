using Microsoft.Extensions.Configuration;

namespace ScreanBotsCommon
{
    public static class ConfigTools
    {
        public static IConfiguration BuildConfig()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();
            return config;
        }
    }
}

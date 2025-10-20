using Microsoft.Extensions.Configuration;
using System.IO;

namespace IpsAusentismos.Infrastructure
{
    public static class Configuration
    {
        public static IConfigurationRoot Current { get; private set; } = null!;
        public static void Load()
        {
            Current = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
        public static string ConnectionString => Current.GetConnectionString("Default")!;
    }
}

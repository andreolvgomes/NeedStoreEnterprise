using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace NSE.Identidade.API.Configuration
{
    public static class StartupConfig
    {
        public static IConfigurationBuilder BuildConfig(this IHostEnvironment hostEnvironment)
        {
            // Uma configuração mais completa e tratando ambiente
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
                builder.AddUserSecrets<Startup>();

            return builder;
        }
    }
}
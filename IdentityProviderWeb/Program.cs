using IdentityProviderInfrastructure.Contexts;
using IdentityProviderInfrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IdentityProviderWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var idpContext = services.GetRequiredService<IdentityProviderDbContext>();

                    // TODO: Register these services
                    // TODO: Only seed when some env var is set
                    var entityBuilder = new IdentityProviderEntityBuilder();
                    var seeder = new IdentityProviderDbSeeder(idpContext, entityBuilder);
                    await seeder.SeedAsync(loggerFactory);
                }
                catch (Exception e)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e.Message);
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

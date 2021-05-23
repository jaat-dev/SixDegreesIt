using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SixDegreesIt.DataAccess.Data;

namespace SixDegreesIt.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            RunSeedDb(host);
            host.Run();
        }

        private static void RunSeedDb(IHost host)
        {
            IServiceScopeFactory scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using IServiceScope scope = scopeFactory.CreateScope();
            SeedDb seeder = scope.ServiceProvider.GetService<SeedDb>();
            seeder.SeedAsync().Wait();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

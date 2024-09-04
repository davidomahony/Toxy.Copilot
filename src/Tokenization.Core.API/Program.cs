using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Tokenization.Core.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddSingleton<IGenericRepository<TenantConfiguration>>(sp =>
//    {
//        var configuration = sp.GetRequiredService<IConfiguration>();
//        return new ConfigurationRepository(configuration);
//    });

//    services.AddSingleton<IConfigurationService, ConfigurationService>();

//    services.AddControllers();
//    // Other service registrations
//}
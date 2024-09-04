using Tokenization.Core.API.Models.Configuration;
using Tokenization.Core.API.Repositories;
using Tokenization.Core.API.Services;

namespace Tokenization.Core.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGenericRepository<TenantConfiguration>>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                return new ConfigurationRepository(configuration);
            });

            services.AddSingleton<IConfigurationService, ConfigurationService>();

            services.AddControllers();
            // Other service registrations
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

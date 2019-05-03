using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace test
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }



        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            StartupConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {

            StartupConfigureServices(services);
        }


        public void StartupConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options =>
               {
               })
                //.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)
                .AddAuthorization();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.ConfigureGlobalExceptionHandler();
            //app.UseAuthentication();
            app.UseMvc();
        }
    }
}
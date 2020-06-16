using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Broidery.Api.DockerStartup
{
    public class Startup : BaseStartup
    {

        public Startup(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration) { }

        public void ConfigureServices(IServiceCollection services)
        {
            BaseConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            BaseConfigure(app, env);
        }
    }
}

using Broidery.Api.DependencyInjection;
using Broidery.Api.StartupExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Elastic.Apm.NetCoreAll;

namespace Broidery.Api
{
    public class BaseStartup
    {
        public BaseStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void BaseConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "EnableConnection",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200/*", "http://192.168.0.135:8081/*").WithMethods("POST", "GET", "PUT");
                    });
            });
            services.EFCoreConfiguration(new EFCoreConfiguration(Configuration.GetConnectionString("DefaultConnection")));
            new ServiceCollectionInjector(services).ResolveServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Broidery API", Version = "v1" });
            });
            services.AddControllers();
        }
        public void BaseConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseAllElasticApm(Configuration);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Broidery API V1");
                c.RoutePrefix = string.Empty;
            });


            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

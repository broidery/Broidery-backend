using Broidery.Api.DependencyInjection;
using Broidery.Api.StartupExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;

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
                        builder.WithOrigins(Environment.GetEnvironmentVariable("CORS_URL_1"), Environment.GetEnvironmentVariable("CORS_URL_2"))
                            .WithMethods("POST", "GET", "PUT", "OPTIONS").AllowAnyHeader();
                    });
            });

            // Configuración de EF Core
            services.EFCoreConfiguration(new EFCoreConfiguration(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION")));

            // Inyección de dependencias
            new ServiceCollectionInjector(services).ResolveServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Broidery API", Version = "v1" });
            });
            services.AddControllers();
            var serviceName = "Broidery-backend";
            var serviceVersion = "1.0.0";
            services.AddOpenTelemetry()
                .WithTracing(b =>
                {
                    b
                    .AddSource(serviceName)
                    .ConfigureResource(resource =>
                        resource.AddService(
                            serviceName: serviceName,
                            serviceVersion: serviceVersion))
                    .AddAspNetCoreInstrumentation()
                    .AddConsoleExporter();
                });
        }
        public void BaseConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Habilitar middleware para servir swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Broidery API V1");
                c.RoutePrefix = string.Empty;
            });

            // Habilitar middleware para redirección HTTPS (opcional)
            // app.UseHttpsRedirection();

            app.UseRouting();

            // Habilitar CORS
            app.UseCors("EnableConnection");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

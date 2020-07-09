using System;
using Microsoft.Extensions.DependencyInjection;

namespace Broidery.Api.DependencyInjection
{
    public abstract class BaseInjector
    {
        private readonly IServiceCollection services;
        public BaseInjector(IServiceCollection _services)
        {
            services = _services ?? throw new ArgumentNullException(nameof(services));
        }
        public abstract void RegisterDependencies();
        protected void RegisterInstancePerRequest<T>() where T : class
        {
            services.AddScoped<T>();
        }
        protected void RegisterInstancePerRequest<T, U>() where T : class where U : class, T
        {
            services.AddScoped<T, U>();
        }
    }
}
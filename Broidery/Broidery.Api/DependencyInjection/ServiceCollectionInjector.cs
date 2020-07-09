using System;
using Microsoft.Extensions.DependencyInjection;

namespace Broidery.Api.DependencyInjection
{
    public class ServiceCollectionInjector
    {
        private readonly IServiceCollection service;

        public ServiceCollectionInjector(IServiceCollection service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        public void ResolveServices()
        {
            new FactoryInjector(service).RegisterDependencies();
            new InteractorInjector(service).RegisterDependencies();
            new RepositoryInjector(service).RegisterDependencies();
        }
    }
}
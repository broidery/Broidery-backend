using System;
using Broidery.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace Broidery.Api.StartupExtensions
{
    public class EFCoreConfiguration
    {
        public readonly string connectionString;

        public EFCoreConfiguration(string _connectionString)
        {
            connectionString = _connectionString ?? throw new ArgumentNullException(nameof(_connectionString));
        }
    }
    public static class EFCoreConfigurationExtension
    {
        public static IServiceCollection EFCoreConfiguration(this IServiceCollection services, EFCoreConfiguration configuration)
        {
            services.AddDbContextPool<BroideryContext>(options =>
            {
                options.UseMySQL(configuration.connectionString);
            });
            return services;
        }
    }
}
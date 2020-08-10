using Broidery.DataAccess;
using Broidery.DataAccess.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Broidery.Api.DependencyInjection
{
    class RepositoryInjector : BaseInjector
    {
        public RepositoryInjector(IServiceCollection services) : base(services) { }
        public override void RegisterDependencies()
        {
            RegisterInstancePerRequest<IUserRepository, UserRepository>();
            RegisterInstancePerRequest<IProductRepository, ProductRepository>();
        }
    }
}
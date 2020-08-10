using Broidery.Interactors;
using Microsoft.Extensions.DependencyInjection;

namespace Broidery.Api.DependencyInjection
{
    public class InteractorInjector : BaseInjector
    {
        public InteractorInjector(IServiceCollection services) : base(services) { }
        public override void RegisterDependencies()
        {
            RegisterInstancePerRequest<AuthenticationInteractor>();
            RegisterInstancePerRequest<ProductsInteractor>();
        }
    }
}
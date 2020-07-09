using Broidery.DataTransferObjects.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Broidery.Api.DependencyInjection
{
    public class FactoryInjector : BaseInjector
    {
        public FactoryInjector(IServiceCollection services) : base(services) { }

        public override void RegisterDependencies()
        {
            RegisterInstancePerRequest<LoginDtoFactory>();
        }
    }
}
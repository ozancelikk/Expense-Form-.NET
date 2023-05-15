using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
            IDependencyInjectionModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }


            return ServiceTool.CreateForMicrosoftDependencies(services);
        }

    }
}

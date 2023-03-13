using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface IDependencyInjectionModule
    {
        void Load(IServiceCollection collection);
    }
}

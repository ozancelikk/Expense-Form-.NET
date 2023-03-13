using Core.Utilities.IoC;
using Microsoft.Extensions.Hosting;

namespace Core.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHost AddHostBuilder(this IHostBuilder hostBuilder)
        {          
            return ServiceTool.CreateForAutofac(hostBuilder);
        }
    }
}

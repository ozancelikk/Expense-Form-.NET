using Business.Abstract;
using Business.Concrete;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public class BusinessModule : IDependencyInjectionModule
    {

        public void Load(IServiceCollection services)
        {
            //Queue service DI           
            services.AddSingleton<IMailConfigService, MailConfigManager>();

        }

    }
}
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Utilities.Interceptors;
using Castle.DynamicProxy;
using Core.Utilities.InterCeptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            ////Manager - Service
            //builder.RegisterType<UsedDeviceManager>().As<IUsedDeviceService>().SingleInstance();
            //builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            //builder.RegisterType<DeviceParserManager>().As<IDeviceParserService>().SingleInstance();
            //builder.RegisterType<QueueHttpManager>().As<IQueueHttpService>().SingleInstance();

            //builder.RegisterType<MailConfigManager>().As<IMailConfigService>().SingleInstance();
            //builder.RegisterType<QueuePublisher>().As<IQueuePublisher>().SingleInstance();


            //builder.RegisterType<DiscoveredDeviceManager>().As<IDiscoveredDeviceService>().SingleInstance();

            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            //builder.RegisterType<SupportedDeviceManager>().As<ISupportedDeviceService>().SingleInstance();

            //builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();

            //builder.RegisterType<UserManager>().As<IUserService>();
            



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                       .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                       {
                           Selector = new AspectInterceptorSelector()
                       }).SingleInstance();

        }
    }
}

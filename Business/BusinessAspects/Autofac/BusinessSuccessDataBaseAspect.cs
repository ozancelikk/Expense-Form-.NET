using Business.Abstract;
using Business.Utilities.Interceptors;
using Castle.DynamicProxy;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.BusinessAspects.AutoFac
{
    public class BusinessSuccessDataBaseAspect : BusinessMethodInterception
    {
        private ISystemInformationsLogService _logService;
        public BusinessSuccessDataBaseAspect()
        {
            _logService = ServiceTool.ServiceProvider.GetService<ISystemInformationsLogService>();

        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _logService.Add(new Core.Entities.Concrete.SystemInformationsLog { Level = "Success", Line = "" ,Target = invocation.TargetType.Name, Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Message = invocation.Method.Name + " başarıyla tamamlandı" });

        }
    }
}
 
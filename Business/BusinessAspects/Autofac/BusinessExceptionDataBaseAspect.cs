using Business.Abstract;
using Business.Utilities.Interceptors;
using Castle.DynamicProxy;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace Business.BusinessAspects.AutoFac
{
    public class BusinessExceptionDataBaseAspect : BusinessMethodInterception
    {
        private ISystemInformationsLogService _logService;
        public BusinessExceptionDataBaseAspect()
        {
            _logService = ServiceTool.Host.Services.GetService<ISystemInformationsLogService>();

        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            var st = new StackTrace(e, true);
            var frame = st.GetFrame(0);
            var methodName = frame.GetMethod().Name;
            var line = frame.GetFileLineNumber();
            _logService.Add(new Core.Entities.Concrete.SystemInformationsLog { Level = "Error", Line = line.ToString(), Target = methodName, Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Message = e.Message });


        }
    }
}
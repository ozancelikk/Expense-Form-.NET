
using Castle.DynamicProxy;
using Core.Aspects.Autofac.ExceptionHandling;
using Core.CrossCuttingConcern.EMail;
using Core.Entities.Concrete;
using Core.Utilities.HardwareInfo.Components;
using Core.Utilities.InterCeptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Core.Aspects.Autofac.Hardware
{
    public class HardwareCpuAspect:MethodInterception
    {       
        private readonly IMailManager _mailManager;
        private readonly IConfiguration _configuration;

        public HardwareCpuAspect()
        {
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            _mailManager = ServiceTool.ServiceProvider.GetService<IMailManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            
            var mailConnection = _configuration.GetSection("EmailConfig").Get<MailConfig>();
            var cpuResults = (List<CPU>)invocation.InvocationTarget.GetType().GetProperty("CpuList").GetValue(invocation.InvocationTarget,null);

            foreach (var cpuItem in cpuResults)
            {
                if (cpuItem.PercentProcessorTime>=90)
                {
                    _mailManager.SendMail(mailConnection, new EMailContent
                    {
                        Body = cpuItem.PercentProcessorTime.ToString(),
                        Subject = "Percent Proccessor Time",
                        IsBodyHtml = true
                    });
                }              
            }
        }
    }
}

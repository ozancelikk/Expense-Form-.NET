using Castle.DynamicProxy;
using Core.CrossCuttingConcern.EMail;
using Core.Entities.Concrete;
using Core.Utilities.HardwareInfo.Components;
using Core.Utilities.InterCeptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Core.Aspects.Autofac.Hardware
{
    public class HardwareMemoryAspect : MethodInterception
    {

        private readonly IMailManager _mailManager;
        private readonly IConfiguration _configuration;
        public HardwareMemoryAspect()
        {
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            _mailManager = ServiceTool.ServiceProvider.GetService<IMailManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            var memory = (MemoryStatus)invocation.InvocationTarget.GetType().GetProperty("MemoryStatus").GetValue(invocation.InvocationTarget, null);
            var emailConfig = _configuration.GetSection("EmailConfig").Get<MailConfig>();

            var memoryStatus = 100*(memory.TotalPhysical - memory.AvailablePhysical) / (memory.TotalPhysical);
            if (memoryStatus>90)
            {
                var subject = $"Memory Status";
                var body = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {memoryStatus.ToString()}%";
                _mailManager.SendMail(emailConfig, new EMailContent
                {
                    Body = body,
                    Subject = subject,
                    IsBodyHtml = emailConfig.EnableSsl
                });
            }
        }
    }
}

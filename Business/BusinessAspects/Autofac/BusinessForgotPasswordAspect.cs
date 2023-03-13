using Business.Abstract;
using Business.Utilities.Interceptors;
using Business.Utilities.MailServices;
using Castle.DynamicProxy;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Business.BusinessAspects.Autofac
{
    public class BusinessForgotPasswordAspect : BusinessMethodInterception
    {

        private IHttpContextAccessor _httpContextAccessor;
        private readonly IMailOperation _mailOperation;
        private readonly IPasswordRecoveryService _passwordRecoveryService;
        public BusinessForgotPasswordAspect()
        {
            _passwordRecoveryService = ServiceTool.Host.Services.GetService<IPasswordRecoveryService>();
            _mailOperation = ServiceTool.Host.Services.GetService<IMailOperation>();
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnAfter(IInvocation invocation)
        {

            var result = (IResult)invocation.ReturnValue;

            if (result.Success)
            {


                Random rastgele = new Random();
                int privateKey = rastgele.Next(1000,100000);
                var passwordRecovery = _passwordRecoveryService.GetByEMail((string)invocation.Arguments[0]);
                if (passwordRecovery.Data != null)
                {
                    passwordRecovery.Data.PrivateKey = privateKey.ToString();
                    _passwordRecoveryService.Update(passwordRecovery.Data);
                }
                else
                {
                    _passwordRecoveryService.Add(new PasswordRecovery { PrivateKey = privateKey.ToString(), UserMailAddress = (string)invocation.Arguments[0] });
                }

                List<string> emails = new List<string>();
                emails.Add((string)invocation.Arguments[0]);
                _mailOperation.SendMailToCustomAddress(emails, "Şifre Yenileme", "Your Activation Code " + privateKey, true);
            }
        }
    }
}

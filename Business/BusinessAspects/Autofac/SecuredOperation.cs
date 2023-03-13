﻿using Business.Abstract;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.InterCeptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserService _userService;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _userService = ServiceTool.Host.Services.GetService<IUserService>();
        }
 
        protected override void OnBefore(IInvocation invocation)
        {
      
                var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
                var userMailAddress = _httpContextAccessor.HttpContext.User.Claims.Where(r => r.Type.Contains("emailaddress")).Select(k => k.Value).FirstOrDefault();
                var user = _userService.GetByMail(userMailAddress);
                if (roleClaims.Contains("employee"))
                {
                foreach (var role in _roles)
                {
                    if (roleClaims.Contains(role))
                    {
                        return;
                    }
                }
                throw new UnauthorizedAccessException(Messages.AuthorizationDenied);
                }
           
                foreach (var role in _roles)
                {
                    if (roleClaims.Contains(role))
                    {
                        return;
                    }
                }

            
         
        
          
            throw new UnauthorizedAccessException(Messages.AuthorizationDenied);
        }
        protected override void OnAfter(IInvocation invocation)
        {
            //var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //if (roleClaims)
            //{

            //}
        }
    }
   
}
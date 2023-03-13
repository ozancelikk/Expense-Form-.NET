using Business.Utilities.Interceptors;
using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace Business.BusinessAspects.AutoFac
{
    public class BusinessExceptionLogAspect : BusinessMethodInterception
    {

        private LoggerServiceBase _loggerServiceBase;

        public BusinessExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException.MethodName + " " + logDetailWithException.ExceptionMessage);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                if (invocation.GetConcreteMethod().GetParameters()[i].Name != null && invocation.Arguments[i] != null)
                {
                    logParameters.Add(new LogParameter
                    {
                        Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                        Value = invocation.Arguments[i],
                        Type = invocation.Arguments[i].GetType().Name
                    });
                }

            }

            var logDetailWithException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetailWithException;
        }

    }
}

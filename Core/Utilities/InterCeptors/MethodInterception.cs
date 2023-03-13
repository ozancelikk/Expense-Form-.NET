using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;

namespace Core.Utilities.InterCeptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        private LoggerServiceBase _loggerServiceBase;
        public MethodInterception()
        {
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(typeof(FileLogger));
        }
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                _loggerServiceBase.Error(e);                
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}

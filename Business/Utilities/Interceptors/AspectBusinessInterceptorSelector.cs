using Business.BusinessAspects.AutoFac;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.InterCeptors;
using System;
using System.Linq;
using System.Reflection;

namespace Business.Utilities.Interceptors
{
    public class AspectBusinessInterceptorSelector : IInterceptorSelector
    {

        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new BusinessExceptionDataBaseAspect());
            classAttributes.Add(new BusinessExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }

    }
}



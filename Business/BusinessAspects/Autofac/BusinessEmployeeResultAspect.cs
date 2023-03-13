using Business.Utilities.Interceptors;
using Castle.DynamicProxy;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
    public class BusinessEmployeeResultAspect: BusinessMethodInterception
    {
        private string _method;
        public BusinessEmployeeResultAspect(string method)
        {
            _method = method;
        }
        protected override void OnAfter(IInvocation invocation)
        {
           
            if (_method == "receipt-getByEmployeeId")
            {
                var data = invocation.ReturnValue as IDataResult<List<Receipt>>;
                invocation.ReturnValue = data.Data.Where(r => r.EmployeeId == "employeeId");
            }
        }
    }
}

using Core.Utilities.IoC;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.DependencyResolvers
{
    public class DataAccessModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection services)
        {
          
            services.AddSingleton<IErrorDal, MongoDB_ErrorDal>();
           
            services.AddSingleton<IUserDal, MongoDB_UserDal>();
            services.AddSingleton<IUserOperationClaimDal, MongoDB_UserOperationClaimDal>();
            services.AddSingleton<IEmployeeOperationClaimDal, MongoDB_EmployeeOperationClaimDal>();
            services.AddSingleton<IOperationClaimDal, MongoDB_OperationClaimDal>();
            services.AddSingleton<IEMailConfigDal, MongoDB_EMailConfigDal>();
        }
    }
}

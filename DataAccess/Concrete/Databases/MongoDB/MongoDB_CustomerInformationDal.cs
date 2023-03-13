using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_CustomerInformationDal : MongoDB_RepositoryBase<CustomerInformation, MongoDB_Context<CustomerInformation, MongoDB_CustomerInformationCollection>>, ICustomerInformationDal
    {
    }
}

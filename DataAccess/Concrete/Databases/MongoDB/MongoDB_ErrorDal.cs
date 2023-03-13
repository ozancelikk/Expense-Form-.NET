using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_ErrorDal : MongoDB_RepositoryBase<Error, MongoDB_Context<Error, MongoDB_ErrorCollection>>, IErrorDal
    {
    }
}

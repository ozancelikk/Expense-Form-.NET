using Core.DataAccess.Databases;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IErrorDal : IEntityRepository<Error>
    {
    }
}

using Core.Utilities.Results;

namespace DataAccess.Concrete.Databases.MongoDB.Utilities.ConnectionResolvers
{
    public interface IDatabase_ConnectionHelper
    {
        IDataResult<DatabaseConnectionSettings> CheckDatabaseConnection();
    }
}
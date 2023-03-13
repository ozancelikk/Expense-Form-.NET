using Core.Utilities.IoC;
using StackExchange.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Core.Entities.Concrete;

namespace Core.CrossCuttingConcern.Caching.Redis
{

    public class RedisService
    {
        ConnectionMultiplexer connectionMultiplexer;
        public void Connect(string connection) => connectionMultiplexer = ConnectionMultiplexer.Connect(connection);
        public IDatabase GetDb(int db) => connectionMultiplexer.GetDatabase(db);

        public RedisService()
        {
            var _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            var redisConfig = _configuration.GetSection("RedisConfig").Get<RedisConfig>();
            Connect(redisConfig.Connection);
        }
    }
}

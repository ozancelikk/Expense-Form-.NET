using Core.CrossCuttingConcern.Caching.Redis;
using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete.Caching.Concrete.Redis
{
    public class Redis_Context : IRedisContext
    {
        public string Connection { get; set; }
        public Redis_Context()
        {
            var _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            var redisConfig = _configuration.GetSection("RedisConfig").Get<RedisConfig>();
            Connection = redisConfig.Connection;
        }
    }
}

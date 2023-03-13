using Core.CrossCuttingConcern.Caching.Redis;
using Core.Entities;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.Caching.Redis
{
    public class Redis_RepositoryBase<RedisConfig, TEntity, RedisContext> : ICachingRepository<TEntity>
        where RedisConfig : class, IRedisConfig, new()
        where TEntity : class, IEntity, new()
        where RedisContext : class, IRedisContext, new()
    {
        private readonly IDatabase _redisDatabase;
        private readonly RedisConfig _redisConfig;
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        public Redis_RepositoryBase()
        {
            _redisConfig = new RedisConfig();
            var redisContext = new RedisContext();
            _connectionMultiplexer = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("REDIS_HOSTNAME") + redisContext.Connection + int.MaxValue);
            _redisDatabase = _connectionMultiplexer.GetDatabase(_redisConfig.Database);
        }

        public void Add(List<TEntity> entities)
        {
            _redisDatabase.StringSetAsync(_redisConfig.CacheName, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(entities)));
        }
        public IList<TEntity> GetAll()
        {
            var result = _redisDatabase.StringGetAsync(_redisConfig.CacheName);
            result.Wait();
            return JsonConvert.DeserializeObject<IList<TEntity>>(result.Result);
        }
        public List<TEntity> GetById(int id)
        {
            var result = _redisDatabase.StringGetAsync(_redisConfig.CacheName);
            result.Wait();
            return JsonConvert.DeserializeObject<List<TEntity>>(result.Result);
        }


        public void Update(List<TEntity> entities)
        {
            _redisDatabase.StringSetAsync(_redisConfig.CacheName, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(entities)));
        }
        public void IcrementHashValueByKey(string key)
        {
            _redisDatabase.HashIncrementAsync(_redisConfig.CacheName, key);
        }
        public void RemoveHashValueByKey(string key)
        {
            _redisDatabase.HashDeleteAsync(_redisConfig.CacheName, key);
        }
        public Dictionary<string, string> GetAllHash()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            var result = _redisDatabase.HashGetAllAsync(_redisConfig.CacheName);
            result.Wait();
            foreach (var item in result.Result)
            {
                keyValuePairs.Add(item.Name, item.Value);
            }
            return keyValuePairs;
        }

    }
}

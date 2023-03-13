using Core.CrossCuttingConcern.Caching.Redis;
using Core.Entities;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System.Collections.Generic;

namespace Core.DataAccess.Caching.Redis
{
    public class RedisClient_Repository<RedisConfig, TEntity, RedisContext> : ICachingClientRepository<TEntity>
        where RedisConfig : class, IRedisConfig, new()
        where TEntity : class, IEntity, new()
        where RedisContext : class, IRedisContext, new()
    {
        RedisConfig _redisConfig;
        RedisContext _redisContext;
        public RedisClient_Repository()
        {
            _redisConfig = new RedisConfig();   
            _redisContext = new RedisContext();
        }

        public void Add(TEntity entity)
        {
            using (IRedisClient client = new RedisClient(_redisContext.Connection))
            {
               
                IRedisTypedClient<TEntity> entityClient = client.As<TEntity>();
             
                entityClient.SetValue(_redisConfig.CacheName, entity);
            }
        }
        public IList<TEntity> GetAll()
        {
            IList<TEntity> entity = new List<TEntity>();
            using (IRedisClient client = new RedisClient(_redisContext.Connection))
            {
                IRedisTypedClient<TEntity> entityClient = client.As<TEntity>();
                entity = entityClient.GetAll();
            }
            return entity;
        }
        public TEntity GetById(int id)
        {
            TEntity entity = new TEntity();
            using (IRedisClient client = new RedisClient(_redisContext.Connection))
            {
                IRedisTypedClient<TEntity> entityClient = client.As<TEntity>();
                entity  = entityClient.GetById(id);
            }
            return entity;
        }
        public void Update(TEntity entity)
        {
            using (IRedisClient client = new RedisClient(_redisContext.Connection))
            {
                IRedisTypedClient<TEntity> entityClient = client.As<TEntity>();
                entityClient.SetValue(_redisConfig.CacheName, entity);
            }
        }
        public void IcrementHashValueByKey(string key)
        {
            using (IRedisClient client = new RedisClient(_redisContext.Connection))
            {
                var entityClient = client.Hashes[_redisConfig.CacheName];
                entityClient.IncrementValue(key, 1);
            }
        }
        public void RemoveHashValueByKey(string key)
        {
            using (IRedisClient client = new RedisClient(_redisContext.Connection))
            {
                var entityClient = client.Hashes[_redisConfig.CacheName];
                entityClient.Remove(key);
            }
        }
        public Dictionary<string,string> GetAllHash()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            using (IRedisClient client = new RedisClient(_redisContext.Connection))
            {
                var entityClient = client.Hashes[_redisConfig.CacheName];
            
                foreach (var item in entityClient.Keys)
                {
                    keyValuePairs.Add(item, entityClient[item]);
                }
            }
            return keyValuePairs;
        }

    }
}

using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.Caching
{
  public interface ICachingRepository<TEntity>
    {
        void Add(List<TEntity> entities);
        IList<TEntity> GetAll();
        List<TEntity> GetById(int id);
        void Update(List<TEntity> entity);
        void IcrementHashValueByKey(string key);
        void RemoveHashValueByKey(string key);
        Dictionary<string, string> GetAllHash();
    }
}

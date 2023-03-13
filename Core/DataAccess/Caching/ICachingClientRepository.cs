using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.Caching
{
    public interface ICachingClientRepository<TEntity>
    {
         void Add(TEntity entity);
         IList<TEntity> GetAll();
         TEntity GetById(int id);
         void Update(TEntity entity);
        void IcrementHashValueByKey(string key);
        void RemoveHashValueByKey(string key);
        Dictionary<string, string> GetAllHash();
    }
}

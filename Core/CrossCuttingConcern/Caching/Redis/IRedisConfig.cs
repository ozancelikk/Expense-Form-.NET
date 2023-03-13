using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcern.Caching.Redis
{
    public interface IRedisConfig
    {
         int Database { get; set; }
         string CacheName { get; set; }
    }
}

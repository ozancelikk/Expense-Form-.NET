using Core.CrossCuttingConcern.Caching.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Caching.Concrete.Redis.Configs
{
    public class Redis_RawLogCountConfig : IRedisConfig
    {
        public int Database { get; set; } = 0;
        public string CacheName { get; set; } = "urn:rawlogcounts:1";
    }
}

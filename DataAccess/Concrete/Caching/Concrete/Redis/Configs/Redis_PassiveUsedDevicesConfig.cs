using Core.CrossCuttingConcern.Caching.Redis;

namespace DataAccess.Concrete.Caching.Concrete.Redis.Configs
{
    public class Redis_PassiveUsedDevicesConfig : IRedisConfig
    {
        public int Database { get; set; } = 0;
        public string CacheName { get; set; } = "urn:passiveuseddevice:1";
    }
}

using Core.CrossCuttingConcern.Caching.Redis;

namespace DataAccess.Concrete.Caching.Concrete.Redis.Configs
{
    public class Redis_ActiveUsedDevicesConfig : IRedisConfig
    {
        public int Database { get; set; } = 0;
        public string CacheName { get; set; } = "urn:activeuseddevice:1";

    }
}

namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_DiscoveredDeviceLogCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_DiscoveredDeviceLogCollection()
        {
            CollectionName = "DiscoveredDevicesLogs";
        }
    }
}

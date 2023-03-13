namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_DiscoveredDeviceCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_DiscoveredDeviceCollection()
        {
            CollectionName = "DiscoveredDevices";
        }
    }
}

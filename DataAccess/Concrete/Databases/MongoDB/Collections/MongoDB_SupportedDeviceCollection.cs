namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_SupportedDeviceCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_SupportedDeviceCollection()
        {
            CollectionName = "SupportedDevices";
        }
    }
}

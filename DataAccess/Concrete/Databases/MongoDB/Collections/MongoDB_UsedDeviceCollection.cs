namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_UsedDeviceCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_UsedDeviceCollection()
        {
            CollectionName = "UsedDevices";
        }
    }
}

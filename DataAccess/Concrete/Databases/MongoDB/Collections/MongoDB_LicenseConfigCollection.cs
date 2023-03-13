namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_LicenseConfigCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_LicenseConfigCollection()
        {
            CollectionName = "LicenseConfigs";
        }
    }
}

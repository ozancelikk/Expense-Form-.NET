namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_EMailConfigCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_EMailConfigCollection()
        {
            CollectionName = "EMailConfigs";
        }
    }
}

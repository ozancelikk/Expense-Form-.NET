namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_ErrorCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_ErrorCollection()
        {
            CollectionName = "Errors";
        }
    }
}

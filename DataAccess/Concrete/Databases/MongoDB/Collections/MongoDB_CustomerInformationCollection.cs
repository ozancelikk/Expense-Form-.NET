namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_CustomerInformationCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_CustomerInformationCollection()
        {
            CollectionName = "CustomerInformations";
        }
    }
}

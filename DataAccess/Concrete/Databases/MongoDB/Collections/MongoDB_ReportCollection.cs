namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_ReportCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_ReportCollection()
        {
            CollectionName = "Reports";
        }
    }
}

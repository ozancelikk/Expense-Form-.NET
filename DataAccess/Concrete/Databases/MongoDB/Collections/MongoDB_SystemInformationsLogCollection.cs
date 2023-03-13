namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_SystemInformationsLogCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_SystemInformationsLogCollection()
        {
            CollectionName = "SystemInformationsLogs";
        }
    }
}

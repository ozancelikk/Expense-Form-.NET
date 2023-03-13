namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_HardwareInformationCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_HardwareInformationCollection()
        {
            CollectionName = "HardwareInformations";
        }
    }
}

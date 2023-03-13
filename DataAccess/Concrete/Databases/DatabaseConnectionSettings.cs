namespace DataAccess.Concrete.Databases
{
    public class DatabaseConnectionSettings
    {
        public string HostName { get; set; }
        public string Database { get; set; }
        public byte[] CompressStandarts { get; set; }
    }
}

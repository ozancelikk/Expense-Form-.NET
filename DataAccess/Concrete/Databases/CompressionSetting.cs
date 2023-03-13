using System;

namespace DataAccess.Concrete.Databases
{
    public class CompressionSetting
    {
        public string Database { get; set; }
        public byte[] CompressStandarts { get; set; }
    }
}

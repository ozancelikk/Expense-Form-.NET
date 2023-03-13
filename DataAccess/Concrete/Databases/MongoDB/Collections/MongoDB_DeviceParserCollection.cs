using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    class MongoDB_DeviceParserCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_DeviceParserCollection()
        {
            CollectionName = "DeviceParser";
        }
    }
}

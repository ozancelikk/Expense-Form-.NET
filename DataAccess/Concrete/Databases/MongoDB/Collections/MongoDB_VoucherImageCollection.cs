using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_VoucherImageCollection:ICollection
    {
        public string CollectionName { get; set; }
        public MongoDB_VoucherImageCollection()
        {
            CollectionName = "Images";
        }
    }
}

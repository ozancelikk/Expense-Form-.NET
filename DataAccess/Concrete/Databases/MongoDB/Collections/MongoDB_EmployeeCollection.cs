using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_EmployeeCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_EmployeeCollection()
        {
            CollectionName = "Employees";
        }
    }
}

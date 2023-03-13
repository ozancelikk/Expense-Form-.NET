using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_EmployeeOperationClaimCollection:ICollection
    {
        public string CollectionName { get; set; }
        public MongoDB_EmployeeOperationClaimCollection()
        {
            CollectionName= "EmployeeOperationClaims";
        }
    }
}

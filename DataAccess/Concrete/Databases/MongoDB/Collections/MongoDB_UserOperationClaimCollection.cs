using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
   public class MongoDB_UserOperationClaimCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_UserOperationClaimCollection()
        {
            CollectionName = "UserOperationClaims";
        }
    }
}

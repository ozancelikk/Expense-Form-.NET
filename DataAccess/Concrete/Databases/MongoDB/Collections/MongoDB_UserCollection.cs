﻿namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_UserCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_UserCollection()
        {
            CollectionName = "Users";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_VouncherCollection : ICollection
    {
        public string CollectionName { get; set; }
        public MongoDB_VouncherCollection()
        {
            CollectionName = "Vounchers";
        }
    }
}

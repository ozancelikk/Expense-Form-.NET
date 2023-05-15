using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Receipt:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DocumentDate { get; set; }
        public double  Total { get; set; }
        public string EmployeeId { get; set; }
        public string DocumentDescription { get; set; }
        public string CompanyName { get; set;}
        public string AuthorizedName { get; set; }
        public string Address { get; set; }

    }
}

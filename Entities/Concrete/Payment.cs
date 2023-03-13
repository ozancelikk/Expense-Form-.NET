using Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string Amount { get; set; }
        public string PaymentChoices { get; set; }
        public string Description { get; set; }
        public bool Pay { get; set; }
    }
}

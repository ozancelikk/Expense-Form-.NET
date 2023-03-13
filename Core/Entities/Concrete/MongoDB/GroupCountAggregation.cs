using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class GroupCountAggregation : MongoDBAggregation
    {

        public int Count { get; set; }
        public List<object> Ids { get; set; }
        public string DDMId { get; set; }
    }
}

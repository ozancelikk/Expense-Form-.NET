using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class ReportStore:IEntity
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<ReportField> ReportFields { get; set; }
        public string ReportTitle { get; set; }
        public string ToCurrentDate { get; set; }
        public string FromCurrentDate { get; set; }
        public string DateOperator { get; set; }
        public string DeviceId { get; set; }
    }
}

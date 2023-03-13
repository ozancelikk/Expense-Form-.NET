using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities.Concrete.DBEntities
{
    public class ScheduledReport : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Schedule Schedule { get; set; }
        public bool IsEnabled { get; set; }
        public Report Report { get; set; }
        public ReportGroup ReportGroup { get; set; }
        public string ReportStoreId { get; set; }
        public string UsedDeviceID { get; set; }
        public string Function { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class UsedDevice : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceDescription { get; set; }
        public List<string> IPAddress { get; set; }
        public bool CorrelationStatus { get; set; }
        public bool DeviceStatus { get; set; }
        public bool DeDuplicationStatus { get; set; }
        public Dictionary<string, bool> CollectedLogDates { get; set; }
        public string DeviceGroupId { get; set; }
    }
}

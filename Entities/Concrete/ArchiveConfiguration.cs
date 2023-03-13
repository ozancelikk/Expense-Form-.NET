using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Concrete
{
    public class ArchiveConfiguration : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ArchiveDirectory { get; set; }
        public string ArchiveTime { get; set; }
        public int ArchiveLimit { get; set; }
        public string OS { get; set; }
        public int ArchiveDelay { get; set; }
        public string Devide { get; set; }

    }
}

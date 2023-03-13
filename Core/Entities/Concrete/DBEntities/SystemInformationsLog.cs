using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities.Concrete
{
    public class SystemInformationsLog:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Date { get; set; }
        public string Target { get; set; }
        public string Level { get; set; }
        public string Line { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}

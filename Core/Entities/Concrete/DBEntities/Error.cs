using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities.Concrete
{
    public class Error:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Date { get; set; }
        public string StackTrade { get; set; }
        public string Level { get; set; }
        public string ErrorLine { get; set; }
        public string ErrorMessage { get; set; }
    }
}

using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Concrete
{
    public class Vouncher : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string ExpenceId { get; set; }
        public string DocumentDate { get; set; }
        public string VouncherNo { get; set; }
        public string Company { get; set; }
        public string VouncherType { get; set; }
        public double TaxRate { get; set; }
        public double Total { get; set; }
        public double TaxTotal { get; set; }
        public double TaxSum { get; set; }
    }
}

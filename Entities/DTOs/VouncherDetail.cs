using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class VouncherDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Employee Employee { get; set; }
        public string ExpenceId { get; set; }
        public string DocumentDate { get; set; }
        public string VouncherNo { get; set; }
        public string Company { get; set; }
        public string VouncherType { get; set; }
        public double TaxRate { get; set; }
        public double Total { get; set; }
        public double TaxTotal { get; set; }
        public double TaxSum { get; set; }
        public string VouncherImage { get; set; }
        public bool Pay { get; set; }
    }
}

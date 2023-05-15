using Entities.Concrete;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UploadReceiptDetailDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Employee Employee { get; set; }
        public string DocumentDate { get; set; }
        public double Total { get; set; }
        public string DocumentDescription { get; set; }
        public string ReceiptImage { get; set; }
        public string CompanyName { get; set; }
        public string AuthorizedName { get; set; }
        public string Address { get; set; }
    }
}

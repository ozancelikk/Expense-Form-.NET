using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UploadReceiptImageDto
    {
        public string ReceiptId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

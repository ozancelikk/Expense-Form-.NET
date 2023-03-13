using Core.Utilities.HardwareInfo.Components;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete.DBEntities
{
    public class HardwareInformation : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public List<CpuCore> CpuCoreList { get; set; }
        public MemoryStatus MemoryStatus { get; set; }
        public List<Drive> Drives { get; set; }

    }
}

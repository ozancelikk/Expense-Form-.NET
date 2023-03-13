using Core.Entities;
using Core.Entities.Concrete.DBEntities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class ReportHistory : Schedule, IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //public string ReportDate { get; set; }
        //public string ReportTime { get; set; }
        //public string ScheduleDay { get; set; }
        //public int ScheduleHour { get; set; }
        //public int ScheduleMinute { get; set; }
        //public string ScheduleMonth { get; set; }
        public List<dynamic> ReportResult { get; set; }
        public string Function { get; set; }
        public string ReportId { get; set; }
        public string ReportDate { get; set; }
        public string ReportTime { get; set; }
        public bool MailStatus { get; set; }
        public string UsedDeviceId { get; set; }
        //public string SchedulerName { get; set; }
        //public string ReportDescription { get; set; }
        //public string ScheduleType { get; set; }

    }
}
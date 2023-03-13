using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class ReportHistoryDto
    {

        public ReportHistory ReportHistory { get; set; }
        public ReportStore ReportStore { get; set; }
        //public string ReportDate { get; set; }
        //public string ReportTime { get; set; }
        //public string ScheduleDay { get; set; }
        //public int ScheduleHour { get; set; }
        //public int ScheduleMinute { get; set; }
        //public List<BsonDocument> ReportResult { get; set; }
        //public string ScheduleMonth { get; set; }
        //public string ReportId { get; set; }
        //public string SchedulerName { get; set; }
        //public string ReportDescription { get; set; }
        //public string ScheduleType { get; set; }

    }
}

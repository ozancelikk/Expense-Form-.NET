namespace Core.Entities.Concrete.DBEntities
{
    public class Schedule
    {
        public int ScheduleHour { get; set; }
        public int ScheduleMinute { get; set; }
        public string SchedulerName { get; set; }
        public string ScheduleType { get; set; }
        public string ScheduleMonth { get; set; }
        public string ScheduleDay { get; set; }
    }
}

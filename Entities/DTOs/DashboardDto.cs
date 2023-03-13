using Core.Entities.Concrete;
using Core.Utilities.HardwareInfo.Components;
using Entities.Concrete;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class DashboardDto
    {

        public List<string> WeeklyLogCountsDays{ get; set; }
        public Dictionary<string,long> WeeklyLogCounts { get; set; }
        public List<string> UsedDeviceBrands { get; set; }
        public List<long> WeeklyLogCountsNumbers { get; set; }
        public List<string> MonthlyLogCountsDays { get; set; }
        public List<long> MonthlyLogCountsNumbers { get; set; }
        public Dictionary<string, long> MonthlyLogCounts { get; set; }
        public List<string> TheMostLogSenderIPAddresses { get; set; }
        public List<string> TheMostLogSenderCountDates { get; set; }
        public List<long> TheMostLogSenderLogCounts { get; set; }
        public List<UsedDeviceBrandCount> UsedDeviceBrandCounts { get; set; }
        public List<SystemInformationsLog> SystemInformationsLogs{ get; set; }
        public List<ReportHistory> ReportHistories { get; set; }

        public Drive Drive { get; set; }

    }

    public class TheMostLogSenderIpAddress
    {
        public string UsedDeviceIPAddress { get; set; }
    }

    public class TheMostLogSenderLogCount
    {
        public long LogCount { get; set; }
    }
    public class TheMostLogSenderCountDate
    {
        public string CountDate { get; set; }
    }
    public class DashboardTheMostLogSender
    {
        public List<string> CountDate { get; set; }
        public long LogCount { get; set; }
        public List<string> UsedDeviceIPAddress { get; set; }

    }

  
    public class UsedDeviceBrandCount
    {
        public int value { get; set; }
        public string name { get; set; }
       
    }
}

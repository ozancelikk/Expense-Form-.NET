using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.WeeklyPartition
{
    public class DatabasePartitionHelper
    {
        private static int partitionRange = 3;
     
        static Dictionary<string, string> threePartitionDataBases = new Dictionary<string, string>()
       {
           {"01","01"},
           {"02","01"},
           {"03","01"},
           {"04","04"},
           {"05","04"},
           {"06","04"},
           {"07","07"},
           {"08","07"},
           {"09","07"},
           {"10","10"},
           {"11","10"},
           {"12","10"},
           {"13","13"},
           {"14","13"},
           {"15","13"},
           {"16","16"},
           {"17","16"},
           {"18","16"},
           {"19","19"},
           {"20","19"},
           {"21","19"},
           {"22","22"},
           {"23","22"},
           {"24","22"},
           {"25","25"},
           {"26","25"},
           {"27","25"},
           {"28","28"},
           {"29","28"},
           {"30","28"},
           {"31","28"},

       };
        static Dictionary<string, string> sevenPartitionDataBases = new Dictionary<string, string>()
       {
           {"01","01"},
           {"02","01"},
           {"03","01"},
           {"04","01"},
           {"05","01"},
           {"06","01"},
           {"07","01"},
           {"08","08"},
           {"09","08"},
           {"10","08"},
           {"11","08"},
           {"12","08"},
           {"13","08"},
           {"14","08"},
           {"15","15"},
           {"16","15"},
           {"17","15"},
           {"18","15"},
           {"19","15"},
           {"20","15"},
           {"21","15"},
           {"22","31"},
           {"23","31"},
           {"24","31"},
           {"25","31"},
           {"26","31"},
           {"27","31"},
           {"28","31"},
           {"29","31"},
           {"30","31"},
           {"31","31"},

       };


        public static string GetDatabaseModel(string day, string month, string year)
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            partitionRange = Convert.ToInt32(configuration.GetSection("MinimizeSettings:CronRange").Value);
            string result = "";
            if (partitionRange == 3)
            {
                result = year + month + threePartitionDataBases.Where(x => x.Key == day).FirstOrDefault().Value;
            }
            else if (partitionRange == 7)
            {
                result = year + month + sevenPartitionDataBases.Where(x => x.Key == day).FirstOrDefault().Value;
            }

            return result;

        }
        public static List<string> GetDatabaseModels(string startDay, string startMonth, string startYear, string endDay, string endMonth, string endYear)
        {
            List<string> result = new List<string>();
            var lastDay = partitionRange == 3 ? "31" : "28";
            int fistPartition = Convert.ToInt32(GetDatabaseModel(startDay, startMonth, startYear));
            int secondPartition = Convert.ToInt32(GetDatabaseModel(endDay, endMonth, endYear));

            for (int i = fistPartition; i <= secondPartition; i += partitionRange)
            {
                var year = i.ToString().Substring(0, 4);
                var month = i.ToString().Substring(4, 2);
                var day = i.ToString().Substring(6);

                if (day == lastDay)
                {
                    day = "01";

                    if (month == "12")
                    {
                        month = "01";
                        year = (Convert.ToInt32(year) + 1).ToString();
                    }
                    else
                    {
                        month = (Convert.ToInt32(month) + 1).ToString().Length == 1 ? "0" + (Convert.ToInt32(month) + 1).ToString() : (Convert.ToInt32(month) + 1).ToString();
                    }
                    i = Convert.ToInt32(year + month + day);
                }
                result.Add(i.ToString());

            }
            return result;
        }
    }
}

using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Job
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public int JobId { get; set; }

        public string JobName { get; set; }
        public string Cron { get; set; }

       
    }

}

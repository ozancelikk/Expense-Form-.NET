using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
   public class RabbitMQQueuesBinding
    {
        public string source { get; set; }
        public string vhost { get; set; }
        public string destination { get; set; }
        public string destination_type { get; set; }
        public string routing_key { get; set; }
        public string properties_key { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
   public class RabbitMQQueue
    {
        public string QueueName { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
        public Dictionary<string, object> Arguments { get; set; }
        
    }
}

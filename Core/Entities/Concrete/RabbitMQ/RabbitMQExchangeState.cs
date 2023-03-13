using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
   public class RabbitMQExchangeState
    {
        public Dictionary<string,string> arguments { get; set; }
        public bool auto_delete { get; set; }
        public bool durable { get; set; }
        public bool Internal { get; set; }
        public List<string> incoming { get; set; }
        public MessageStats message_stats { get; set; }
        public string name { get; set; }
        public List<string> outgoing { get; set; }
        public string type { get; set; }
        public string user_who_performed_action { get; set; }
        public string vhost { get; set; }

    }

    public class MessageStats
    {
        public int publish_in { get; set; }
        public Dictionary<string,double> publish_in_details { get; set; }       
        public int publish_out { get; set; }
        public Dictionary<string, double> publish_out_details { get; set; }

    }
}

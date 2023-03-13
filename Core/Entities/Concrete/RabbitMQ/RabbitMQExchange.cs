using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
   public class RabbitMQExchange
    {
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
        public bool Durable { get; set; }
        public bool AutoDelete { get; set; }
        public Dictionary<string, object> AlternateExchangeArgs { get; set; }

     
    }
}

using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
   public class RabbitMQConfiguration
    {
        public List<RabbitMQQueue> RabbitMQQues { get; set; }
        public List<RabbitMQExchange> RabbitMQExchanges { get; set; }
        public List<RabbitMQBind> RabbitMQBindings { get; set; }
    }
}

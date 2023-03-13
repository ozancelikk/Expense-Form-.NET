using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete.RabbitMQ
{
    public class RabbitMQErrorResponse
    {
        public string error { get; set; }
        public string reason { get; set; } 
    }
}

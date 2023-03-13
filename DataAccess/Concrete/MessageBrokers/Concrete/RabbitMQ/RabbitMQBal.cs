using Core.DataAccess.MessageBrokers.Abstract;
using Core.DataAccess.MessageBrokers.Concrete.RabbitMQ;
using DataAccess.Concrete.MessageBrokers.Abstract;

namespace DataAccess.Concrete.MessageBrokers.Concrete.RabbitMQ
{
    public class RabbitMQBal : RabbitMQBroker, IQueueBal
    {
        public RabbitMQBal(IRepository repository) : base(repository)
        {

        }
    }
}

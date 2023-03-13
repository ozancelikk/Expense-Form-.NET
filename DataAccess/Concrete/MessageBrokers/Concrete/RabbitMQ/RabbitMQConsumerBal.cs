using Core.DataAccess.MessageBrokers.Abstract;
using Core.DataAccess.MessageBrokers.Concrete.RabbitMQ;
using DataAccess.Concrete.MessageBrokers.Abstract;

namespace MessageBroker.Concrete.RabbitMQ
{
    public class RabbitMQConsumerBal : RabbitMQConsumer, IQueueConsumerBal
    {
        public RabbitMQConsumerBal(IRepository repository) : base(repository)
        {

        }


    }
}

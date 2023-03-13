using Core.DataAccess.MessageBrokers.Abstract;
using Core.DataAccess.MessageBrokers.Concrete.RabbitMQ;
using DataAccess.Concrete.MessageBrokers.Abstract;
using RabbitMQ.Client;

namespace MessageBroker.Concrete.RabbitMQ
{
    public class RabbitMQPublisherBal : RabbitMQPublisher, IQueuePublisherBal
    {
        public IModel model { get; set; }
        public RabbitMQPublisherBal(IRepository queueRepository) : base(queueRepository)
        {
            model = base.channel;
        }

    }
}

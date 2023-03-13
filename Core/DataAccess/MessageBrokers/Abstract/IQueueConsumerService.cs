using RabbitMQ.Client.Events;

namespace Core.DataAccess.MessageBrokers.Abstract
{
    public interface IQueueConsumerService
    {
        bool Add(BasicDeliverEventArgs eventArgs);
    }
}

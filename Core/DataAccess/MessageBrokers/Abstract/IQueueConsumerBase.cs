using RabbitMQ.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.DataAccess.MessageBrokers.Abstract
{
    public interface IQueueConsumerBase
    {
        Task Consume(IQueueConsumerService queueConsumedDataBase, string queueName, bool auto_Ack);
    }
}

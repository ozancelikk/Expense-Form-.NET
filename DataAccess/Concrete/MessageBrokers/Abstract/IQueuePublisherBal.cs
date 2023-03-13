using Core.DataAccess.MessageBrokers.Abstract;
using RabbitMQ.Client;

namespace DataAccess.Concrete.MessageBrokers.Abstract
{
    public interface IQueuePublisherBal : IQueuePublisherBase
    {
        IModel model { get; set; }
    }
}

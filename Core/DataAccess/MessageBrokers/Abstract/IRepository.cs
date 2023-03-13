using RabbitMQ.Client;

namespace Core.DataAccess.MessageBrokers.Abstract
{
    public interface IRepository
    {
        IModel TryConnectionToMessageBroker();

        IConnection TryConnectionToMessageBrokerWithoutModel();
    }
}

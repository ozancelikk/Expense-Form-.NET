using Core.Entities.Concrete;
using Core.Utilities.Results;
using RabbitMQ.Client;
using System.Net.Sockets;

namespace Core.DataAccess.MessageBrokers.Abstract
{
    public interface IQueuePublisherBase
    {
        void Publish(string exchangeName, string routingKey, IBasicProperties basicProperties, byte[] messageBodyBytes);
        void PublishErrorData(IDataResult<SystemInformationsLog> errorResult);
    }
}

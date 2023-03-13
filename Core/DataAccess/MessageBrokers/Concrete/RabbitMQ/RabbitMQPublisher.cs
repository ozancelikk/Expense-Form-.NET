using Core.DataAccess.MessageBrokers.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Core.DataAccess.MessageBrokers.Concrete.RabbitMQ
{
    public class RabbitMQPublisher : IQueuePublisherBase
    {
        public IModel channel;
        public RabbitMQPublisher(IRepository queueRepository)
        {
            channel = queueRepository.TryConnectionToMessageBroker();
        }


        public void Publish(string exchangeName, string routingKey, IBasicProperties basicProperties, byte[] messageBodyBytes)
        {
            
            channel.BasicPublish(exchangeName, routingKey, basicProperties, messageBodyBytes);

        }


        public void PublishErrorData(IDataResult<SystemInformationsLog> errorResult)
        {
            var _errorResult = JsonConvert.SerializeObject(errorResult);
            channel.QueueDeclare(queue: "Errors", durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicPublish(exchange: "", routingKey: "Errors", basicProperties: null, body: Encoding.UTF8.GetBytes(_errorResult));
        }
    }
}

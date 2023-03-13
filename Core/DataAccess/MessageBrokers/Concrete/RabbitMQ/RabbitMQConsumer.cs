using Core.DataAccess.MessageBrokers.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace Core.DataAccess.MessageBrokers.Concrete.RabbitMQ
{
    public class RabbitMQConsumer : IQueueConsumerBase
    {
        private IRepository _repository;

        public RabbitMQConsumer(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(IQueueConsumerService queueConsumerService, string queueName, bool auto_Ack)
        {
            var channel = _repository.TryConnectionToMessageBroker();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                queueConsumerService.Add(ea);
                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume(queue: queueName, auto_Ack, consumer: consumer);
            await Task.Yield();
        }


    }
}


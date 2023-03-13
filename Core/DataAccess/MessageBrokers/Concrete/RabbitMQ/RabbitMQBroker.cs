using Core.DataAccess.MessageBrokers.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
using Core.Utilities.Results;

namespace Core.DataAccess.MessageBrokers.Concrete.RabbitMQ
{
    public class RabbitMQBroker : IQueueBrokerBase
    {
        private IRepository _repository;
        public RabbitMQBroker(IRepository queueRepository)
        {
            _repository = queueRepository;

        }

        public IResult CreateQueue(RabbitMQQueue rabbitMQQueue)
        {
            var channel = _repository.TryConnectionToMessageBroker();
            channel.QueueDeclare(rabbitMQQueue.QueueName, rabbitMQQueue.Durable, rabbitMQQueue.Exclusive, rabbitMQQueue.AutoDelete, rabbitMQQueue.Arguments);
            channel.Close();
            return new SuccessResult(QueueMessages.ANewQueueCreated);
        }

        public IResult DeleteQueue(string queueName, bool ifUnused, bool ifEmpty)
        {
            var channel = _repository.TryConnectionToMessageBroker();
            channel.QueueDelete(queueName, ifUnused, ifEmpty);
            channel.Close();
            return new SuccessResult(QueueMessages.AnQueueDeleted);
        }
        public IDataResult<uint> GetMessageCountFromQueue(string queue)
        {
            var channel = _repository.TryConnectionToMessageBroker();
            return new SuccessDataResult<uint>(channel.MessageCount(queue));

        }

        public IResult PurgeQueue(string queueName)
        {
            var channel = _repository.TryConnectionToMessageBroker();
            channel.QueuePurge(queueName);
            channel.Close();
            return new SuccessResult(QueueMessages.AMessageQueuePurged);
        }
        public IResult UnbindQueue(RabbitMQBind rabbitMQBind)
        {
            var channel = _repository.TryConnectionToMessageBroker();
            channel.QueueUnbind(rabbitMQBind.QueueName, rabbitMQBind.ExchangeName, rabbitMQBind.RoutingKey, rabbitMQBind.Arguments);
            channel.Close();
            return new SuccessResult(QueueMessages.UnBindingProcessCompleted);
        }
        public IResult BindQueue(RabbitMQBind rabbitMQBind)
        {
            var channel = _repository.TryConnectionToMessageBroker();
            channel.QueueBind(rabbitMQBind.QueueName, rabbitMQBind.ExchangeName, rabbitMQBind.RoutingKey, rabbitMQBind.Arguments);
            channel.Close();
            return new SuccessResult(QueueMessages.BindingProcessCompleted);
        }

        public IResult CreateExchange(RabbitMQExchange rabbitMQExchange)
        {
            var channel = _repository.TryConnectionToMessageBroker();
            channel.ExchangeDeclare(rabbitMQExchange.ExchangeName, rabbitMQExchange.ExchangeType, rabbitMQExchange.Durable, rabbitMQExchange.AutoDelete, rabbitMQExchange.AlternateExchangeArgs);
            channel.Close();
            return new SuccessResult(QueueMessages.ANewExchangeDeclared);
        }

    }
}

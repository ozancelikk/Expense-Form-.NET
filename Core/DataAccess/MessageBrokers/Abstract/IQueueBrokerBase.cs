using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Core.DataAccess.MessageBrokers.Abstract
{
    public interface IQueueBrokerBase
    {
        IResult CreateQueue(RabbitMQQueue rabbitMQQueue);
        IResult DeleteQueue(string queueName, bool ifUnused, bool ifEmpty);
        IResult PurgeQueue(string queueName);
        IResult BindQueue(RabbitMQBind rabbitMQBind);
        IResult CreateExchange(RabbitMQExchange rabbitMQExchange);
        IResult UnbindQueue(RabbitMQBind rabbitMQBind);
        IDataResult<uint> GetMessageCountFromQueue(string queue);
    }
}

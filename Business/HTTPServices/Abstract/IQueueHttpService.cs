using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.HTTPServices.Abstract
{
    public interface IQueueHttpService
    {
        IDataResult<List<RabbitMQQueuesBinding>> GetQueueBindings(string queueName);
        IDataResult<RabbitMQExchangeState> GetExchangeInformations(string exchangeName);
        IDataResult<int> GetQueueUnackedCount(string queueName);
        IDataResult<int> GetQueueMessagesCount(string queueName);
        IDataResult<int> GetQueueReadyMessages(string queueName);
        IDataResult<int> GetQueueReadyMessagesRam(string queueName);
        IDataResult<int> GetQueueMessagesRam(string queueName);
        IDataResult<int> GetQueueBytesMessagesRam(string queueName);
        IDataResult<int> GetQueueBytesMessagesReady(string queueName);
        IDataResult<int> GetQueueMemoryKBDetail(string queueName);
        IDataResult<int> GetPublishDetails(string queueName);
    }
}

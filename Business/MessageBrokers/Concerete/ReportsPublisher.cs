using Business.Abstract;
using Business.Constants;
using Business.MessageBrokers.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete.MessageBrokers.Abstract;
using System.Collections.Generic;
using System.Text;

namespace Business.MessageBrokers.Concerete
{
    public class ReportsPublisher : IReportsPublisher
    {

        private IQueuePublisherBal _queuePublisherBal;

        public ReportsPublisher(IQueuePublisherBal queuePublisherBal)
        {
            _queuePublisherBal = queuePublisherBal;
        }

        public IResult Publish(string collectionName, string messageType)
        {
            var properties = _queuePublisherBal.model.CreateBasicProperties();

            properties.Persistent = false;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("collectionName", collectionName);
            properties.Headers = dictionary;
            _queuePublisherBal.Publish("", "Oriana-Reports-Queue", properties, Encoding.UTF8.GetBytes(messageType));

            return new SuccessResult(Messages.NewLogAdded);

        }
    }
}

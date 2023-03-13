using Business.Abstract;
using Business.Constants;
using Business.MessageBrokers.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete.MessageBrokers.Abstract;
using System.Collections.Generic;
using System.Text;

namespace Business.MessageBrokers.Concerete
{
    public class RawLogArchivePublisher : IRawLogArchivePublisher
    {

        private readonly IQueuePublisherBal _queuePublisherBal;

        public RawLogArchivePublisher(IQueuePublisherBal queuePublisherBal)
        {
            _queuePublisherBal = queuePublisherBal;
        }

        public IResult Add(string log, string collectionName)
        {
              
            var properties = _queuePublisherBal.model.CreateBasicProperties();

            properties.Persistent = false;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("deviceId", collectionName);
            properties.Headers = dictionary;

            _queuePublisherBal.Publish("", "Oriana-RawLog-Daily-Archiving-Queue", properties, Encoding.UTF8.GetBytes(log));
                return new SuccessResult(Messages.NewLogAdded);
       
        
        }
    }
}

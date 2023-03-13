using Business.MessageBrokers.Abstract.Publishers;
using Core.Utilities.Results;
using DataAccess.Concrete.MessageBrokers.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.MessageBrokers.Concerete.Publishers
{
    public class MailPublisher : IMailPublisher
    {

        private readonly IQueuePublisherBal _queuePublisherBal;

        public MailPublisher(IQueuePublisherBal queuePublisherBal)
        {
            _queuePublisherBal = queuePublisherBal;
        }

        public IResult Add(string subject, string message, string type)
        {
            var properties = _queuePublisherBal.model.CreateBasicProperties();
            properties.Persistent = false;
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("subject", subject);
            dictionary.Add("type", type);
            properties.Headers = dictionary;
            _queuePublisherBal.Publish("", "Oriana-Mail-Queue", properties, Encoding.UTF8.GetBytes(message));
            return new SuccessResult();
        }

  

    }
}

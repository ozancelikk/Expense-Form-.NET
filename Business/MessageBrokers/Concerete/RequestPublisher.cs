using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.MessageBrokers.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete.MessageBrokers.Abstract;
using System.Collections.Generic;
using System.Text;

namespace Business.MessageBrokers.Concerete
{
    public class RequestPublisher : IRequestPublisher
    {
        private readonly IQueuePublisherBal _queuePublisherBal;
        public RequestPublisher(IQueuePublisherBal queuePublisherBal)
        {
            _queuePublisherBal = queuePublisherBal;
        }
        [SecuredOperation("suser,admin,customArchive.Create")]
        public IResult PublishToCustomArchiveForAllUsedDevice(string archiveDate)
        {
            var properties = _queuePublisherBal.model.CreateBasicProperties();

            properties.Persistent = false;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("archiveDate", archiveDate);
            properties.Headers = dictionary;

            var data = Encoding.UTF8.GetBytes("CreateCustomArchiveForAllUsedDevice");
            _queuePublisherBal.Publish("", "Oriana-Requests-Queue", properties, data);
            return new SuccessResult(Messages.MessageSentSuccessfully);
        }

       [SecuredOperation("suser,admin,customArchive.Create")]
        public IResult PublishToCustomArchiveForUsedDevice(string archiveDate, string usedDeviceId)
        {
            var properties = _queuePublisherBal.model.CreateBasicProperties();

            properties.Persistent = false;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("archiveDate", archiveDate);
            dictionary.Add("usedDeviceId", usedDeviceId);
            properties.Headers = dictionary;

            var data = Encoding.UTF8.GetBytes("CreateCustomArchiveForUsedDevice");
            _queuePublisherBal.Publish("", "Oriana-Requests-Queue", properties, data);

            return new SuccessResult(Messages.MessageSentSuccessfully);
        }

        [SecuredOperation("suser,admin")]
        public IResult PublishToRequestsQueue1(string request, List<string> deviceIPAddress,List<string> deviceOldIPAddress)
        {


            var properties = _queuePublisherBal.model.CreateBasicProperties();

            properties.Persistent = false;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("deviceIPAddress", deviceIPAddress);
            dictionary.Add("deviceOldIPAddress", deviceOldIPAddress);
            properties.Headers = dictionary;

            var data = Encoding.UTF8.GetBytes(request);
            _queuePublisherBal.Publish("", "Oriana-Requests-Queue", properties, data);
            return new SuccessResult(Messages.MessageSentSuccessfully);


        }


        [SecuredOperation("suser,admin")]
        public IResult PublishToRequestsQueue(string request, string usedDeviceId)
        {


            var properties = _queuePublisherBal.model.CreateBasicProperties();

            properties.Persistent = false;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("usedDeviceId", usedDeviceId);
            properties.Headers = dictionary;

            var data = Encoding.UTF8.GetBytes(request);
            _queuePublisherBal.Publish("", "Oriana-Requests-Queue", properties, data);
            return new SuccessResult(Messages.MessageSentSuccessfully);


        }


    }
}

using Core.Utilities.Results;

namespace Business.MessageBrokers.Abstract
{
    public interface IReportsPublisher
    {
        IResult Publish(string collectionName, string messageType);
    }
}

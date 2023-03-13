using Core.Utilities.Results;
using System.Diagnostics;

namespace Business.MessageBrokers.Abstract.Publishers
{
    public interface IMailPublisher
    {
        IResult Add(string subject,string message, string type);

    }
}

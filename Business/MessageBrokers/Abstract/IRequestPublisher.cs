using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.MessageBrokers.Abstract
{
    public interface IRequestPublisher
    {
        IResult PublishToCustomArchiveForAllUsedDevice(string archiveDate);
        IResult PublishToCustomArchiveForUsedDevice(string archiveDate, string usedDeviceId);
        IResult PublishToRequestsQueue(string request, string usedDeviceId);
        IResult PublishToRequestsQueue1(string request, List<string> deviceIPAddress, List<string> deviceOldIPAddress);
    }
}

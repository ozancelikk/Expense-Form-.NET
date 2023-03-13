using System.Net.NetworkInformation;

namespace Core.Utilities.Network.Abstract
{
    public interface IPingHelper
    {
        PingReply Send(string ipAddress);
    }
}

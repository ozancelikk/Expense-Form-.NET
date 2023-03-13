using Core.Utilities.Network.Abstract;
using System.Net.NetworkInformation;

namespace Core.Utilities.Network.Concrete
{
    public class PingHelper : IPingHelper
    {
        public PingReply Send(string ipAddress)
        {
            Ping ping = new Ping();
            PingOptions pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            byte[] numArray = new byte[32];
            string hostNameOrAddress = ipAddress;
            int timeout = 300;
            byte[] buffer = numArray;
            PingOptions options = pingOptions;
            return ping.Send(hostNameOrAddress, timeout, buffer, options);

        }
    }
}

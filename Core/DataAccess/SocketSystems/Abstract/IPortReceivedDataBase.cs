using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Core.DataAccess.SocketSystems.Abstract
{
   public interface IPortReceivedDataBase
    {
        IResult Add(UdpReceiveResult udpReceiveResult);
    }
}

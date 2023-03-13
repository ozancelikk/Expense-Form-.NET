using System.Collections.Generic;

namespace Core.DataAccess.SocketSystems.Abstract
{
    public interface IListenPorts
    {
        List<int> PortList { get; set; }
    }
}

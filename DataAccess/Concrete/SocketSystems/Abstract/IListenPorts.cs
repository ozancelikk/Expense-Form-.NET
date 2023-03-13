using System.Collections.Generic;

namespace DataAccess.Concrete.SocketSystems.Abstract
{
    public interface IListenPorts
    {
        List<int> PortList { get; set; }
    }
}

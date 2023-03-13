using Core.DataAccess.SocketSystems.Abstract;
using System.Collections.Generic;

namespace DataAccess.Concrete.SocketSystems.Concrete
{
    public class ListenPorts : IListenPorts
    {
        public List<int> PortList { get; set; }
    }
}

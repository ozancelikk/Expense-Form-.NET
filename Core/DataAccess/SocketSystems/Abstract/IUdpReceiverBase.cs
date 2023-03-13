using Core.DataAccess.SocketSystems.Abstract;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DataAccess.SocketSystems.Abstract
{
    public interface IUdpReceiverBase
    {
        Task Publish(CancellationToken stoppingToken, IPortReceivedDataBase portReceivedDataBase, int portNumberToListen);

    }
}

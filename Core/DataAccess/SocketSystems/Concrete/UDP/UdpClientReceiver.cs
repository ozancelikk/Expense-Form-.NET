using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.DataAccess.SocketSystems.Abstract;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DataAccess.SocketSystems.Concrete.UDP
{
    public class UdpClientReceiver : IUdpReceiverBase
    {

        private LoggerServiceBase _loggerServiceBase;
        public UdpClientReceiver()
        {
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(typeof(FileLogger));

        }

        public async Task Publish(CancellationToken stoppingToken, IPortReceivedDataBase portReceivedDataBase, int portNumberToListen)
        {

            StartListen(stoppingToken, portReceivedDataBase, portNumberToListen);
            await Task.Yield();

        }
        private async void StartListen(CancellationToken stoppingToken, IPortReceivedDataBase portReceivedDataBase, int portNumberToListen)
        {
            try
            {
                UdpClient _udpClient = new UdpClient(portNumberToListen);
                await Receive(stoppingToken, portReceivedDataBase, _udpClient);
            }
            catch (Exception e)
            {
                _loggerServiceBase.Error(e);
                throw;
            }

        }

        private async Task Receive(CancellationToken stoppingToken, IPortReceivedDataBase portReceivedDataBase, UdpClient udpClient)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Factory.StartNew(() =>
                    {
                        
                        
                        portReceivedDataBase.Add(udpClient.ReceiveAsync().Result);

                    });
                    await Task.Yield();
                }
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                _loggerServiceBase.Error(e);
                throw;
            }

        }

    }
}

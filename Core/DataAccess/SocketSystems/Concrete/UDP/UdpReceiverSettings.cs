using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Core.DataAccess.SocketSystems.Concrete.UDP
{
    public static class UdpReceiverSettings
    {
        public static List<int> ports { get; set; }
        private static LoggerServiceBase _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(typeof(FileLogger));
    
  
        public static List<int> GetPorts()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            var portList = configuration.GetSection(nameof(ListenPorts)).Get<ListenPorts>();
            
            if (portList.PortList.Count < 1)
            {
                _loggerServiceBase.Error("Wrong port entry");
                throw new Exception("Wrong port entry");

            }         
                ports = new List<int>();
                if (portList != null)
                {
                    foreach (var port in portList.PortList)
                    {
                        ports.Add(port);
                    }
                }
                return ports;
           
           

        }
    }
}

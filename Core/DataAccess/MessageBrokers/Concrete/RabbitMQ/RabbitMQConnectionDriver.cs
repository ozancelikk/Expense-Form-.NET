using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.DataAccess.MessageBrokers.Abstract;
using RabbitMQ.Client;
using System;
using System.Threading;

namespace Core.DataAccess.MessageBrokers.Concrete.RabbitMQ
{
    public class RabbitMQConnectionDriver : IRepository
    {
        private LoggerServiceBase _loggerServiceBase;
        private readonly QueueConnectionSettings _queueConnectionSettings;
        public RabbitMQConnectionDriver()
        {
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(typeof(FileLogger));
            _queueConnectionSettings = new QueueConnectionSettings();
        }


        [TransactionScopeAspect]
        public IModel TryConnectionToMessageBroker()
        {
            int start = 1;
            int limit = 4;
        tryAgain:
            try
            {
                var factory = new ConnectionFactory() { HostName = _queueConnectionSettings.HostName, Port = _queueConnectionSettings.Port, UserName = _queueConnectionSettings.UserName, Password = _queueConnectionSettings.Password };
                var connection = factory.CreateConnection();
                _loggerServiceBase.Info("RabbitMQ server is running");
                return connection.CreateModel();
            }
            catch (System.Exception e)
            {
                if (start <= limit)
                {
                    start++;
                    Thread.Sleep(5000);
                    goto tryAgain;
                }
                _loggerServiceBase.Error(e);
                throw;
            }

        }

        public IConnection TryConnectionToMessageBrokerWithoutModel()
        {
            int start = 1;
            int limit = 4;
        tryAgain:
            try
            {
                var factory = new ConnectionFactory() { HostName = _queueConnectionSettings.HostName, Port = _queueConnectionSettings.Port, UserName = _queueConnectionSettings.UserName, Password = _queueConnectionSettings.Password };
                var connection = factory.CreateConnection();

                return connection;
            }
            catch (System.Exception e)
            {
                if (start <= limit)
                {
                    start++;
                    Thread.Sleep(5000);
                    goto tryAgain;
                }
                _loggerServiceBase.Error(e);
                throw;
            }
        }
    }
}

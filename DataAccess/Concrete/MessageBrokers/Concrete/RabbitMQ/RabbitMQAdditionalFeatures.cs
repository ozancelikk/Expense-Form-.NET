using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Concrete.MessageBrokers.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MessageBrokers.Concrete.RabbitMQ
{
    public class RabbitMQAdditionalFeatures : IQueueAdditionalFeaturesService
    {

        private RabbitMQConfiguration _queueConfiguration;
        private IQueueBal _queueBrokerAccessLayer;
        public RabbitMQAdditionalFeatures(IQueueBal queueBrokerAccessLayer)
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            _queueConfiguration = configuration.GetSection(nameof(RabbitMQConfiguration)).Get<RabbitMQConfiguration>();
            _queueBrokerAccessLayer = queueBrokerAccessLayer;


        }
        public async Task ApplyDefaultConfigurations()
        {
            List<IResult> results = new List<IResult>();

            foreach (var rabbitMQExchange12 in _queueConfiguration.RabbitMQExchanges)
            {
                results.Add(_queueBrokerAccessLayer.CreateExchange(rabbitMQExchange12));
            }
            foreach (var rabbitmqQueue in _queueConfiguration.RabbitMQQues)
            {
                if (rabbitmqQueue.Arguments != null)
                {
                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                    foreach (var argument in rabbitmqQueue.Arguments)
                    {
                        keyValuePairs.Add(argument.Key, Convert.ToInt32(argument.Value));
                    }
                    rabbitmqQueue.Arguments = keyValuePairs;
                }
                results.Add(_queueBrokerAccessLayer.CreateQueue(rabbitmqQueue));
            }
            foreach (var rabbitMQBinding in _queueConfiguration.RabbitMQBindings)
            {
                results.Add(_queueBrokerAccessLayer.BindQueue(rabbitMQBinding));
            }
            await Task.CompletedTask;

        }

    }
}

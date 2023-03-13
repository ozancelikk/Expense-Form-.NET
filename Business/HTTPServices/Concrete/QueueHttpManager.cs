using Business.BusinessAspects.Autofac;
using Business.HTTPServices.Abstract;
using Core.DataAccess.MessageBrokers.Concrete;
using Core.Entities.Concrete;
using Core.Entities.Concrete.RabbitMQ;
using Core.Utilities.HTTP;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.HTTPServices.Concrete
{
    public class QueueHttpManager : IQueueHttpService
    {
        private readonly QueueConnectionSettings rabbitMQConnectionSetting;
        public QueueHttpManager()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            rabbitMQConnectionSetting = new QueueConnectionSettings();
        }
        /// <summary>
        /// RabbitMQ Exchange bilgilerini verir.
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<RabbitMQExchangeState> GetExchangeInformations(string exchangeName)
        {


            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {

                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/exchanges/%2F/{exchangeName}");
                response.Wait();
            }
            if (!response.Result.Contains("error"))
            {
                var discoveredDeviceQueueBindings = JsonConvert.DeserializeObject<RabbitMQExchangeState>(response.Result);
                return new SuccessDataResult<RabbitMQExchangeState>(discoveredDeviceQueueBindings);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);

            throw new UnauthorizedAccessException(errorResponse.reason);


        }
        /// <summary>
        /// Belirtilen kuyruktaki bind değerlerini verir.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<List<RabbitMQQueuesBinding>> GetQueueBindings(string queueName)
        {



            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}/bindings");
                response.Wait();
            }
            if (!response.Result.Contains("error"))
            {
                var discoveredDeviceQueueBindings = JsonConvert.DeserializeObject<List<RabbitMQQueuesBinding>>(response.Result);
                discoveredDeviceQueueBindings.RemoveAt(0);
                return new SuccessDataResult<List<RabbitMQQueuesBinding>>(discoveredDeviceQueueBindings);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);
            throw new UnauthorizedAccessException(errorResponse.reason);
        }

        public IDataResult<int> GetPublishDetails(string queueName)
        {
            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}");
                response.Wait();
            }
            if (!response.Result.Contains("error"))
            {
                var result = JObject.Parse(response.Result);

                return new SuccessDataResult<int>(Convert.ToInt32(result["message_stats"]["publish_details"]["rate"]) * 3);
            }
            return new SuccessDataResult<int>(0); ;
        }


        /// <summary>
        /// Belirtilen kuyruk hakkında detaylar içeren bir sonuç döndürür. Kuyruktaki mesaj boyutu, consumer sayısı vb.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<int> GetQueueMemoryKBDetail(string queueName) 
        {

            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}");
                response.Wait();
            }

        
            if (!response.Result.Contains("error"))
            {
                var result = JObject.Parse(response.Result);
             
              
                var QueueMemoryKBDetail = ((int)result["memory"] / 512) ;


                return new SuccessDataResult<int>(QueueMemoryKBDetail);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);
            throw new UnauthorizedAccessException(errorResponse.reason);
        }
        /// <summary>
        /// Belirtilen kuyrukta consumerlar tarafından toplanıp henüz işlenmemiş mesaj sayısını verir.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<int> GetQueueUnackedCount(string queueName)
        {


            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}");
                response.Wait();
            }


            if (!response.Result.Contains("error"))
            {
                var result = JObject.Parse(response.Result);
                var unAckedCount = (int)result["messages_unacknowledged"];
                return new SuccessDataResult<int>(unAckedCount);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);
            throw new UnauthorizedAccessException(errorResponse.reason);

        }
        /// <summary>
        /// Belirtilen kuyruktaki henüz consume edilmeyen mesaj sayısını verir.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<int> GetQueueReadyMessages(string queueName)
        {


            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}");
                response.Wait();
            }


            if (!response.Result.Contains("error"))
            {
                var result = JObject.Parse(response.Result);
                var unAckedCount = (int)result["messages_ready"];
                return new SuccessDataResult<int>(unAckedCount);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);
            throw new UnauthorizedAccessException(errorResponse.reason);
        }
        /// <summary>
        /// Belirtilen kuyruktaki ram üzerinde tutulan ve henüz consume edilmemiş mesaj sayısını verir.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<int> GetQueueReadyMessagesRam(string queueName)
        {

            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}");
                response.Wait();
            }


            if (!response.Result.Contains("error"))
            {
                var result = JObject.Parse(response.Result);
                var unAckedCount = (int)result["messages_ready_ram"];
                return new SuccessDataResult<int>(unAckedCount);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);
            throw new UnauthorizedAccessException(errorResponse.reason);
        }
        /// <summary>
        /// Belirtilen kuyruktaki ram üzerinde tutulan mesaj sayısını verir.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<int> GetQueueMessagesRam(string queueName)
        {


            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}");
                response.Wait();
            }


            if (!response.Result.Contains("error"))
            {
                var result = JObject.Parse(response.Result);
                var unAckedCount = (int)result["messages_ram"];
                return new SuccessDataResult<int>(unAckedCount);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);
            throw new UnauthorizedAccessException(errorResponse.reason);
        }
        /// <summary>
        /// Belirtilen kuyruktaki ram üzerinde tutulan mesajların byte türünden boyutunu verir.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<int> GetQueueBytesMessagesRam(string queueName)
        {


            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}");
                response.Wait();
            }


            if (!response.Result.Contains("error"))
            {
                var result = JObject.Parse(response.Result);
                var unAckedCount = (int)result["message_bytes_ram"];
                return new SuccessDataResult<int>(unAckedCount);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);
            throw new UnauthorizedAccessException(errorResponse.reason);
        }
        /// <summary>
        /// Belirtilen kuyruktaki ram üzerinde tutulan ve henüz consume edilmemiş mesajların byte türünden boyutunu verir.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<int> GetQueueBytesMessagesReady(string queueName)
        {


            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}");
                response.Wait();
            }


            if (!response.Result.Contains("error"))
            {
                var result = JObject.Parse(response.Result);
                var unAckedCount = (int)result["message_bytes_ready"];
                return new SuccessDataResult<int>(unAckedCount);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);
            throw new UnauthorizedAccessException(errorResponse.reason);
        }
        /// <summary>
        /// Belirtilen kuyruktaki mesaj sayısını verir.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        [SecuredOperation("suser,admin,user")]
        public IDataResult<int> GetQueueMessagesCount(string queueName)
        {


            Task<string> response;
            using (var httpClientService = new HttpClientService(rabbitMQConnectionSetting.UserName, rabbitMQConnectionSetting.Password))
            {
                response = httpClientService.GetRequest($"http://{rabbitMQConnectionSetting.HostName}:{rabbitMQConnectionSetting.ApiPort}/api/queues/%2F/{queueName}");
                response.Wait();
            }


            if (!response.Result.Contains("error"))
            {
                var result = JObject.Parse(response.Result);
                var messagesCount = (int)result["messages"];
                return new SuccessDataResult<int>(messagesCount);
            }
            var errorResponse = JsonConvert.DeserializeObject<RabbitMQErrorResponse>(response.Result);
            throw new UnauthorizedAccessException(errorResponse.reason);
        }

    }
}

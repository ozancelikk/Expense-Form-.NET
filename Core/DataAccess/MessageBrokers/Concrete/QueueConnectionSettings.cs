using System;

namespace Core.DataAccess.MessageBrokers.Concrete
{
    public class QueueConnectionSettings
    {

        public string HostName { get; set; } = Environment.GetEnvironmentVariable("QUEUE_HOSTNAME");
        public string UserName { get; set; } = Environment.GetEnvironmentVariable("QUEUE_USERNAME");
        public string Password { get; set; } = "0is5sWIJ10epuChaQAspObewr0TRlPhis4A9rucrLGeMosWuwROphoSoDiBA5tlD";
        public int Port { get; set; } = Convert.ToInt32(Environment.GetEnvironmentVariable("QUEUE_PORT"));
        public int ApiPort { get; set; } = Convert.ToInt32(Environment.GetEnvironmentVariable("QUEUE_APIPORT"));

    }
}

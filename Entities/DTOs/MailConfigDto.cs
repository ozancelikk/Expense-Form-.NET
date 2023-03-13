using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MailConfigDto
    {
        public string SmtpServer { get; set; }
        public string From { get; set; }
        public List<string> To { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}

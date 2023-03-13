using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentGetDto
    {
        public Employee Employee { get; set; }
        public string Amount { get; set; }
        public string PaymentChoices { get; set; }
        public string Description { get; set; }
        public bool Pay { get; set; }
    }
}

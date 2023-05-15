using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentDto:IDto
    {
        public string EmployeeId{ get; set; }
        public string Amount { get; set; }
        public string PaymentChoices { get; set; }
        public string Description { get; set; }
        public bool Pay { get; set; }
    }
}

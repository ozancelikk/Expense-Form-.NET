using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ExpenceDto:IDto
    {
        public string EmployeeId { get; set; }
        public string Date { get; set; }
    }
}

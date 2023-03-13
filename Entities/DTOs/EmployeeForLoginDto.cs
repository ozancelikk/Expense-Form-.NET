using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EmployeeForLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

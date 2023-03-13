using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.DTOs
{
    public class EmployeeOperationClaimDto :IDto
    {
        public string EmployeeId { get; set; }
        public string OperationClaimId { get; set; }
    }
}

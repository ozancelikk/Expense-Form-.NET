﻿using Core.Entities;

namespace Entities.DTOs
{
    public class UserOperationClaimDto:IDto
    {
        public string UserId { get; set; }
        public string OperationClaimId { get; set; }
    }
}

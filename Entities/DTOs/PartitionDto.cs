using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PartitionDto:IDto
    {
        public bool PartitionStatus { get; set; }
        public long TotalPage { get; set; }
        public Dictionary<string, PartitionDto> PartitionDevice { get; set; }
    }
}

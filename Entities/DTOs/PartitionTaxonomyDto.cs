using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PartitionTaxonomyDto:IDto
    {
        public bool PartitionStatus { get; set; }
        public long TotalPage { get; set; }
        public Dictionary<string, PartitionDeviceDto> PartitionDevice { get; set; }
    }

    public class PartitionDeviceDto : IDto
    {
        public long TotalPage { get; set; }
        public Dictionary<string, PartitionDeviceStatus> PartitionDeviceStatus { get; set; }
    }
    public class PartitionDeviceStatus : IDto
    {
        public long TotalPage { get; set; }
        public bool PartitionStatus { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PartitionRawLogDto
    {
        public string CollectionName { get; set; }
        public long Page { get; set; }
        public int Limit { get; set; }
        public Dictionary<string,PartitionDto> Partition { get; set; }
    }
}

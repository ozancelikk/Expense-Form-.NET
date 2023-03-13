using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    
    public class PartitionResult<T,TDto> : DataResult<T>, IPartitionResult<T,TDto>
    {
        public PartitionResult(T data, bool success, string message, TDto partition) : base(data, success, message)
        {
            PartitionData = partition;
        }
        public PartitionResult(T data, bool success, TDto partition) : base(data, success)
        {
            PartitionData = partition;
        }

        public TDto PartitionData { get; }
    }
}

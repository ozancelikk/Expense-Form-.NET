using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessPartitionDataResult<T,TDto> : PartitionResult<T,TDto>
    {
        public SuccessPartitionDataResult(T data, TDto partition) : base(data, true, partition)
        {
        }

        public SuccessPartitionDataResult(T data, string message, TDto partition) :
            base(data, true, message, partition)
        {
        }
        public SuccessPartitionDataResult(string message, TDto partition) :
            base(default, true, message, partition)
        { }
        public SuccessPartitionDataResult(TDto partition) :
            base(default, true, partition)
        { }

    }
}

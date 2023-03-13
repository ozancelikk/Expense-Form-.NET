using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorPartitionDataResult<T,TDto>:PartitionResult<T,TDto>
    {
        public ErrorPartitionDataResult(T data, TDto partition,int previousPage) :
            base(data, false, partition)
        {
        }

        public ErrorPartitionDataResult(T data, string message,TDto partition) :
            base(data, false, message, partition)
        {
        }
        public ErrorPartitionDataResult(string message, TDto partition) :
            base(default, false, message, partition)
        { }
        public ErrorPartitionDataResult(TDto partition) :
            base(default, false, partition)
        { }
    }
}

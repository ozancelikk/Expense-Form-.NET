using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IPartitionResult<T,TDto>:IDataResult<T>
    {
        TDto PartitionData { get; }
    }
}

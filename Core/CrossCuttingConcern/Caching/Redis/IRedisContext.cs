using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcern.Caching.Redis
{
    public interface IRedisContext
    {
        string Connection { get; set; }
    }
}

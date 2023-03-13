using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ChartSerie<T>
    {
        public T data { get; set; }
        public List<string> xAxisData { get; set; }
    }
}

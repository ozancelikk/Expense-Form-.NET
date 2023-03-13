using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class DatabaseConnectionResult
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public bool Success { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Exceptions
{
    public class FileHelperCustomException:Exception, ICustomException
    {
        public FileHelperCustomException(string message):base(message)
        {
        
        }
    }
}

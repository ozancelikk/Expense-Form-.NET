using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Compression.Abstract
{
    public interface ICompressService
    {
        void Compress(string FolderToCompress, string destination);
      
    }
}

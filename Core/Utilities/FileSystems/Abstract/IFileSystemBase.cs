using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileSystems.Abstract
{
    public interface IFileSystemBase
    {
        void CreateDirectory(string path);
        void CreateFile(string path);
        void DeleteFile(string path);
        void DeleteDirectory(string path);
        void WriteLine(string path, string content);
        void WriteAllLines(string path, List<string> contents);
        
    }
}

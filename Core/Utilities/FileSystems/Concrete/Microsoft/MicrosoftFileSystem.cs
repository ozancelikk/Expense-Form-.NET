using Core.Utilities.FileSystems.Abstract;
using System.Collections.Generic;
using System.IO;

namespace Core.Utilities.FileSystems.Concrete.Microsoft
{
    public class MicrosoftFileSystem : IFileSystemBase
    {
        public void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

        }

        public void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path)) { }
            }
        }
    
        public void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                
            }
        }
        public void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        public void WriteLine(string path, string content)
        {
            if (File.Exists(path))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
                {
                    file.WriteLine(content);
                }
            }

        }

        public void WriteAllLines(string path, List<string> contents)
        {
           
            if (!File.Exists(path))
            {
                CreateFile(path);
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                for (int i = 0; i < contents.Count; i++)
                {
                    file.WriteLine(contents[i]);
                }

            }

        }
    }
}

using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFileSystemService
    {
        IResult CreateDirectory(string path);
        IResult CreateFile(string path);
        IResult DeleteFile(string path);
        IResult DeleteDirectory(string path);
        IResult WriteLine(string path, string content);
        IResult WriteAllLines(string path, List<string> contents);

    }
}

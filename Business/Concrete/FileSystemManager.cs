using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.FileSystems.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class FileSystemManager : IFileSystemService
    {
        private readonly IFileSystemDal _fileSystemDal;
        public FileSystemManager(IFileSystemDal fileSystemDal)
        {
            _fileSystemDal = fileSystemDal;
        }
        [SecuredOperation("suser,admin,file.CreateDirectory")]
        public IResult CreateDirectory(string path)
        {
            _fileSystemDal.CreateDirectory(path);
            return new SuccessResult(Messages.NewLogAdded);
        }
        [SecuredOperation("suser,admin,file.CreateFile")]
        public IResult CreateFile(string path)
        {
            _fileSystemDal.CreateFile(path);
            return new SuccessResult(Messages.NewLogAdded);
        }
        [SecuredOperation("suser,admin,file.DeleteFile")]
        public IResult DeleteFile(string path)
        {
            _fileSystemDal.DeleteFile(path);
            return new SuccessResult(Messages.NewLogAdded);
        }
        [SecuredOperation("suser,admin,file.DeleteDirectory")]
        public IResult DeleteDirectory(string path)
        {
            _fileSystemDal.DeleteDirectory(path);
            return new SuccessResult(Messages.NewLogAdded);
        }
        [SecuredOperation("suser,admin,file.Write")]
        public IResult WriteAllLines(string path, List<string> contents)
        {
            _fileSystemDal.WriteAllLines(path, contents);
            return new SuccessResult(Messages.NewLogAdded);
        }
        [SecuredOperation("suser,admin,file.Write")]
        public IResult WriteLine(string path, string content)
        {
            _fileSystemDal.WriteLine(path, content);
            return new SuccessResult(Messages.NewLogAdded);
        }
    }
}

using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    internal class LoginActivitiesManager : ILoginActivitiesService
    {
        private readonly ILoginActivitiesDal _loginActivitiesDal;
        public LoginActivitiesManager(ILoginActivitiesDal loginActivitiesDal)
        {
            _loginActivitiesDal = loginActivitiesDal;

        }
        [SecuredOperation("suser,admin,loginActivities.Add")]
        public IResult Add(LoginActivities loginActivities)
        {
            _loginActivitiesDal.Add(loginActivities);
            return new SuccessResult(Messages.AddingSuccessful);
        }
        [SecuredOperation("suser,admin,loginActivities.Delete")]
        public IResult Delete(LoginActivities loginActivities)
        {
            var result = _loginActivitiesDal.Delete(loginActivities);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }
        [SecuredOperation("suser,admin,loginActivities.Get")]
        public IDataResult<LoginActivities> Get()
        {
            return new SuccessDataResult<LoginActivities>(_loginActivitiesDal.Get(), Messages.Successful);
        }
        [SecuredOperation("suser,admin,loginActivities.Get")]
        public IDataResult<List<LoginActivities>> GetAll()
        {
            var result = _loginActivitiesDal.GetAll();
            return new SuccessDataResult<List<LoginActivities>>(result, $"{result.Count} Adet Aktivite");
        }
        [SecuredOperation("suser,admin,loginActivities.Get")]
        public IDataResult<LoginActivities> GetById(string id)
        {
            return new SuccessDataResult<LoginActivities>(_loginActivitiesDal.Get(l => l.Id == id), Messages.Successful);
        }
    }
}

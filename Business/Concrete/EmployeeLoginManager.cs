using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EmployeeLoginManager : IEmployeeLoginActivitiesService
    {
        private readonly IEmployeeLoginActivitiesDal _employeeLoginActivitiesDal;
        public EmployeeLoginManager(IEmployeeLoginActivitiesDal employeeLoginActivitiesDal)
        {
            _employeeLoginActivitiesDal = employeeLoginActivitiesDal;
        }

        public IResult Add(EmployeeLoginActivities employeeLoginActivities)
        {
            _employeeLoginActivitiesDal.Add(employeeLoginActivities);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(EmployeeLoginActivities employeeLoginActivities)
        {
            var result= _employeeLoginActivitiesDal.Delete(employeeLoginActivities);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }

        public IDataResult<EmployeeLoginActivities> Get()
        {
            return new SuccessDataResult<EmployeeLoginActivities>(_employeeLoginActivitiesDal.Get(), Messages.Successful);
        }

        public IDataResult<List<EmployeeLoginActivities>> GetAll()
        {
            var result = _employeeLoginActivitiesDal.GetAll();
            return new SuccessDataResult<List<EmployeeLoginActivities>>(result, $"{result.Count} Adet Aktivite");
        }

        public IDataResult<EmployeeLoginActivities> GetById(string id)
        {
            return new SuccessDataResult<EmployeeLoginActivities>(_employeeLoginActivitiesDal.Get(l => l.Id == id), Messages.Successful);
        }
    }
}

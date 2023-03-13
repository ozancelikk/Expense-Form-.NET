using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmployeeLoginActivitiesService
    {
        IDataResult<EmployeeLoginActivities> GetById(string id);
        IDataResult<List<EmployeeLoginActivities>> GetAll();
        IResult Add(EmployeeLoginActivities employeeLoginActivities);
        IResult Delete(EmployeeLoginActivities employeeLoginActivities);
        IDataResult<EmployeeLoginActivities> Get();
    }
}

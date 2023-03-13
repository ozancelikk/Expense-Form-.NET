using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_EmployeeLoginActivitiesDal : MongoDB_RepositoryBase<EmployeeLoginActivities, MongoDB_Context<EmployeeLoginActivities, MongoDB_EmployeeLoginActivitiesCollection>>, IEmployeeLoginActivitiesDal
    {
    }
}

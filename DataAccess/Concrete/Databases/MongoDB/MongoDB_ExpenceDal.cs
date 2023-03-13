using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_ExpenceDal:MongoDB_RepositoryBase<Expence,MongoDB_Context<Expence,MongoDB_ExpenceCollection>>, IExpenceDal
    {
        //public ExpenceDetailDto GetDetailWithExpence()
        //{
        //    List<Expence> _expences = new List<Expence>();
        //    List<Vouncher> _vounchers = new List<Vouncher>();
        //    List<Employee> _employees = new List<Employee>();
        //    List<ExpenceDetailDto> _expenceDetailDtos = new List<ExpenceDetailDto>();

        //    using (var expence = new MongoDB_Context<Expence, MongoDB_ExpenceCollection>())
        //    {
        //        _expences = expence.collection.Find<Expence>(document => true).ToList();
        //    }
        //    using (var vouncher = new MongoDB_Context<Vouncher, MongoDB_VouncherCollection>())
        //    {
        //        _vounchers = vouncher.collection.Find<Vouncher>(document => true).ToList();
        //    }
        //    using (var employee = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
        //    {
        //        _employees = employee.collection.Find<Employee>(document => true).ToList();
        //    }
        //    foreach (var employee in _employees)
        //    {
        //        var currentEmployee = _expenceDetailDtos.Where(e => e.EmployeeId == employee.Id).FirstOrDefault();
        //        var currentExpence = _vounchers.Where(e => e.EmployeeId == employee.Id).FirstOrDefault();
        //        ExpenceDetailDto expenceDetailDto = new ExpenceDetailDto()
        //        {
        //            Id = employee.Id,
        //            ExpenceId = currentEmployee.ExpenceId,
        //            EmployeeId = currentEmployee.EmployeeId,
        //        };
        //        _expenceDetailDtos.Add(expenceDetailDto);
        //    }
        //    return _expenceDetailDtos;
        //}


        




        //DORU OLAN 
        //public ExpenceDetailDto GetDetailWithExpence(string expenceId)
        //{
        //    List<Employee> employee = new List<Employee>();
        //    using (var employees = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
        //    {
        //        employees.GetMongoDBCollection();
        //        employee = employees.collection.Find<Employee>(document => true).ToList();
        //    }

        //    foreach (var item in employee)
        //    {
        //        ExpenceDetailDto expenceDetailDto = new ExpenceDetailDto
        //        {
        //            EmployeeId = item.Id,
                    
        //        };

        //    }
        //    return expenceDetailDto;


        //}
    }
}

using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_VouncherDal : MongoDB_RepositoryBase<Vouncher, MongoDB_Context<Vouncher, MongoDB_VouncherCollection>>, IVouncherDal
    {
        public List<VouncherGetDto> GetDetailByVouncherId(string id)
        {
            List<Vouncher> vounchers = new List<Vouncher>();
            using (var vouncherContext = new MongoDB_Context<Vouncher, MongoDB_VouncherCollection>())
            {
                vouncherContext.GetMongoDBCollection();
                vounchers = vouncherContext.collection.Find<Vouncher>(document => true).ToList();
            }

            List<EmployeeDto> employees = new List<EmployeeDto>();
            using (var employee=new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employee.GetMongoDBCollection();
                foreach (var emp in employees)
                {
                    if (emp.Id!=null)
                    {
                        employees.Add(new EmployeeDto
                        {
                            Id = emp.Id,
                            Department = emp.Department,
                            Name = emp.Name,
                            Surname = emp.Surname,
                        });
                    }
                }

            }


            List<VouncherGetDto> employeeGetDtos = new List<VouncherGetDto>();
            using (var employeeContext = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employeeContext.GetMongoDBCollection();
                foreach (var vouncher in vounchers)
                {
                    if (vouncher.EmployeeId != null)
                    {
                        employeeGetDtos.Add(new VouncherGetDto
                        {
                            Employee = employeeContext.collection.Find<Employee>(r => r.Id == vouncher.EmployeeId).FirstOrDefault(),
                            Company = vouncher.Company,
                            DocumentDate = vouncher.DocumentDate,
                            ExpenceId = vouncher.ExpenceId,
                            TaxRate = vouncher.TaxRate,
                            TaxSum = vouncher.TaxSum,
                            TaxTotal = vouncher.TaxTotal,
                            Total = vouncher.Total,
                            VouncherNo = vouncher.VouncherNo,
                            VouncherType = vouncher.VouncherType,
                            Id = vouncher.Id,
                        });
                    }

                }


            }


            return employeeGetDtos.Where(x=>x.Employee.Id==id).ToList();
        }

        public List<VouncherGetDto> GetDetailWithVouncher()
        {

            List<Vouncher> vounchers = new List<Vouncher>();
            using (var vouncherContext = new MongoDB_Context<Vouncher, MongoDB_VouncherCollection>())
            {
                vouncherContext.GetMongoDBCollection();
                vounchers = vouncherContext.collection.Find<Vouncher>(document => true).ToList();
            }
            List<EmployeeDto> employees = new List<EmployeeDto>();
            using (var employee = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employee.GetMongoDBCollection();
                foreach (var emp in employees)
                {
                    if (emp.Id != null)
                    {
                        employees.Add(new EmployeeDto
                        {
                            Id = emp.Id,
                            Department = emp.Department,
                            Name = emp.Name,
                            Surname = emp.Surname,
                        });
                    }
                }

            }


            List<VouncherGetDto> employeeGetDtos = new List<VouncherGetDto>();
            using (var employeeContext = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employeeContext.GetMongoDBCollection();
                foreach (var vouncher in vounchers)
                {
                    if (vouncher.EmployeeId != null)
                    {
                        employeeGetDtos.Add(new VouncherGetDto
                        {
                            Employee = employeeContext.collection.Find<Employee>(r => r.Id == vouncher.EmployeeId).FirstOrDefault(),
                            Company = vouncher.Company,
                            DocumentDate = vouncher.DocumentDate,
                            ExpenceId = vouncher.ExpenceId,
                            TaxRate= vouncher.TaxRate,
                            TaxSum= vouncher.TaxSum,
                            TaxTotal= vouncher.TaxTotal,
                            Total = vouncher.Total,
                            VouncherNo = vouncher.VouncherNo,
                            VouncherType = vouncher.VouncherType,
                            Id= vouncher.Id,
                        });
                    }
                
                }
               
            }


            return employeeGetDtos;


        }
        public VouncherDetail GetWithVouncher()
        {

            List<Vouncher> vounchers = new List<Vouncher>();
            using (var vouncherContext = new MongoDB_Context<Vouncher, MongoDB_VouncherCollection>())
            {
                vouncherContext.GetMongoDBCollection();
                vounchers = vouncherContext.collection.Find<Vouncher>(document => true).ToList();
            }
            List<EmployeeDto> employees = new List<EmployeeDto>();
            using (var employee = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employee.GetMongoDBCollection();
                foreach (var emp in employees)
                {
                    if (emp.Id != null)
                    {
                        employees.Add(new EmployeeDto
                        {
                            Id = emp.Id,
                            Department = emp.Department,
                            Name = emp.Name,
                            Surname = emp.Surname,
                        });
                    }
                }

            }

            List<VouncherDetail> employeeGetDtos = new List<VouncherDetail>();
            using (var employeeContext = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employeeContext.GetMongoDBCollection();
                foreach (var vouncher in vounchers)
                {
                    if (vouncher.EmployeeId != null)
                    {
                        employeeGetDtos.Add(new VouncherDetail
                        {
                            Id= vouncher.Id,
                            Employee = employeeContext.collection.Find<Employee>(r => r.Id == vouncher.EmployeeId).FirstOrDefault(),
                            Company = vouncher.Company,
                            DocumentDate = vouncher.DocumentDate,
                            ExpenceId = vouncher.ExpenceId,
                            TaxRate = vouncher.TaxRate,
                            TaxSum = vouncher.TaxSum,
                            TaxTotal = vouncher.TaxTotal,
                            Total = vouncher.Total,
                            VouncherNo = vouncher.VouncherNo,
                            VouncherType = vouncher.VouncherType,
                        });
                    }

                }

            }


            return employeeGetDtos.First();


        }
    }
}

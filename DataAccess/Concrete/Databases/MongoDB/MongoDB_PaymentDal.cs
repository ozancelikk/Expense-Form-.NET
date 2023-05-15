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
    public class MongoDB_PaymentDal:MongoDB_RepositoryBase<Payment, MongoDB_Context<Payment, MongoDB_PaymentCollection>>, IPaymentDal
    {
        public List<PaymentGetDto> GetDetailWithPayment()
        {
            List<Payment> payments = new List<Payment>();
            using (var paymentContext = new MongoDB_Context<Payment, MongoDB_PaymentCollection>())
            {
                paymentContext.GetMongoDBCollection();
                payments =paymentContext.collection.Find<Payment>(document=> true).ToList();
            }

            List<PaymentGetDto> employeeGetDtos = new List<PaymentGetDto>();
            using (var employeeContext = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employeeContext.GetMongoDBCollection();
                foreach (var payment in payments)
                {
                    if (payment.EmployeeId != null)
                    {
                        employeeGetDtos.Add(new PaymentGetDto
                        {
                            Employee = employeeContext.collection.Find<Employee>(r => r.Id == payment.EmployeeId).FirstOrDefault(),
                            Amount= payment.Amount,
                            Description= payment.Description,
                            Pay = payment.Pay,
                            PaymentChoices = payment.PaymentChoices
                        });
                    }

                }

            }
            return employeeGetDtos;
        }

        public List<PaymentGetDto> GetWithEmployeeId(string id)
        {
            List<Payment> payments = new List<Payment>();
            List<PaymentGetDto> paymentGetDto = new List<PaymentGetDto>();
            using (var paymentContext = new MongoDB_Context<Payment, MongoDB_PaymentCollection>())
            {
                paymentContext.GetMongoDBCollection();
                payments = paymentContext.collection.Find<Payment>(document => true).ToList();
            }
            using (var employeeContect = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employeeContect.GetMongoDBCollection();

                foreach (var payment in payments)
                {
                    paymentGetDto.Add(new PaymentGetDto
                    {
                        Amount = payment.Amount,
                        Description = payment.Description, 
                        Pay = payment.Pay,  
                        PaymentChoices = payment.PaymentChoices,
                        Employee = employeeContect.collection.Find<Employee>(e => e.Id == payment.EmployeeId).FirstOrDefault()

                    });
                }
            }
            return paymentGetDto.Where(x => x.Employee.Id == id).ToList();

        }

        public List<PaymentGetDto> GetAllWithEmployee()
        {
            List<Payment> payments = new List<Payment>();
            using (var paymentContext = new MongoDB_Context<Payment, MongoDB_PaymentCollection>())
            {
                paymentContext.GetMongoDBCollection();
                payments = paymentContext.collection.Find<Payment>(document => true).ToList();
            }

            List<PaymentGetDto> employeeGetDtos = new List<PaymentGetDto>();
            using (var employeeContext = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employeeContext.GetMongoDBCollection();
                foreach (var payment in payments)
                {
                    if (payment.EmployeeId != null)
                    {
                        employeeGetDtos.Add(new PaymentGetDto
                        {
                            Employee = employeeContext.collection.Find<Employee>(r => r.Id == payment.EmployeeId).FirstOrDefault(),
                            Amount = payment.Amount,
                            Description = payment.Description,
                            Pay = payment.Pay,
                            PaymentChoices = payment.PaymentChoices
                        });
                    }

                }

            }
            return employeeGetDtos;
        }
    }
}

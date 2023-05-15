using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
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
    public class MongoDB_ReceiptDal : MongoDB_RepositoryBase<Receipt, MongoDB_Context<Receipt, MongoDB_ReceiptCollection>>, IReceiptDal
    {
        public List<ReceiptGetDto> GetDetailByEmployeeId(string id)
        {
            List<Receipt> receipts = new List<Receipt>();
            using (var receiptContext = new MongoDB_Context<Receipt, MongoDB_ReceiptCollection>())
            {
                receiptContext.GetMongoDBCollection();
                receipts = receiptContext.collection.Find<Receipt>(document => true).ToList();
            }

            List<ReceiptGetDto> receiptGetDtos = new List<ReceiptGetDto>();
            using (var employeeContext = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employeeContext.GetMongoDBCollection();
                foreach (var receipt in receipts)
                {
                    if (receipt.EmployeeId != null)
                    {
                        receiptGetDtos.Add(new ReceiptGetDto
                        {
                            Id = receipt.Id,
                            Employee = employeeContext.collection.Find<Employee>(r => r.Id == receipt.EmployeeId).FirstOrDefault(),
                            Address = receipt.Address,
                            AuthorizedName = receipt.AuthorizedName,
                            CompanyName = receipt.CompanyName,
                            DocumentDate = receipt.DocumentDate,
                            DocumentDescription = receipt.DocumentDescription,
                            Total = receipt.Total,
                        });
                    }
                }
            }
            return receiptGetDtos.Where(x => x.Employee.Id == id).ToList();
        }
    

        public List<ReceiptGetDto> GetDetailWithReceipt()
        {
            List<Receipt> receipts = new List<Receipt>();
            using (var receiptContext = new MongoDB_Context<Receipt, MongoDB_ReceiptCollection>())
            {
                receiptContext.GetMongoDBCollection();
                receipts = receiptContext.collection.Find<Receipt>(document => true).ToList();
            }

            List<ReceiptGetDto> receiptGetDtos = new List<ReceiptGetDto>();
            using (var employeeContext = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employeeContext.GetMongoDBCollection();
                foreach (var receipt in receipts)
                {
                    if (receipt.EmployeeId != null)
                    {
                        receiptGetDtos.Add(new ReceiptGetDto
                        {
                            Id=receipt.Id,
                            Employee = employeeContext.collection.Find<Employee>(r => r.Id == receipt.EmployeeId).FirstOrDefault(),
                            Address = receipt.Address,
                            AuthorizedName = receipt.AuthorizedName,
                            CompanyName = receipt.CompanyName,
                            DocumentDate = receipt.DocumentDate,
                            DocumentDescription = receipt.DocumentDescription,
                            Total = receipt.Total,
                        });
                    }
                }
            }
            return receiptGetDtos;
        }

        public UploadReceiptDetailDto GetReceiptDetails(string id)
        {
            List<Receipt> receipts = new List<Receipt>();
            using (var receiptContext = new MongoDB_Context<Receipt, MongoDB_ReceiptCollection>())
            {
                receiptContext.GetMongoDBCollection();
                receipts = receiptContext.collection.Find<Receipt>(document => true).ToList();
            }

            List<UploadReceiptDetailDto> receiptGetDtos = new List<UploadReceiptDetailDto>();
            using (var employeeContext = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employeeContext.GetMongoDBCollection();
                foreach (var receipt in receipts)
                {
                    if (receipt.EmployeeId != null)
                    {
                        receiptGetDtos.Add(new UploadReceiptDetailDto 
                        {
                            Id=receipt.Id,
                            Employee = employeeContext.collection.Find<Employee>(r => r.Id == receipt.EmployeeId).FirstOrDefault(),
                            Address = receipt.Address,
                            AuthorizedName = receipt.AuthorizedName,
                            CompanyName = receipt.CompanyName,
                            DocumentDate = receipt.DocumentDate,
                            DocumentDescription = receipt.DocumentDescription,
                            Total = receipt.Total,
                        });
                    }
                }
            }
            return receiptGetDtos.Find(x=>x.Id==id);
        }
    }
}

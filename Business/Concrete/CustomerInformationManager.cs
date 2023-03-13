using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerInformationManager : ICustomerInformationService
    {
        private readonly ICustomerInformationDal _customerInformationDal;
        public CustomerInformationManager(ICustomerInformationDal customerInformationDal)
        {
            _customerInformationDal = customerInformationDal;
        }
        [ValidationAspect(typeof(CustomerInformationValidator))]
        public IResult Add(CustomerInformation customerInformation)
        {

            IResult result = BusinessRules.Run(CustomerInformationExists());

            if (result != null)
            {
                return result;
            }

            _customerInformationDal.Add(customerInformation);
                return new SuccessResult(Messages.AddingSuccessful);
           
       
            
        }

        [SecuredOperation("suser,admin,customer.Get,employee")]
        public IDataResult<List<CustomerInformation>> GetAll()
        {
            return new SuccessDataResult<List<CustomerInformation>>(_customerInformationDal.GetAll(), Messages.Successful);
        }
        [SecuredOperation("suser,admin,customer.Get,employee")]
        public IDataResult<CustomerInformation> Get()
        {
            return new SuccessDataResult<CustomerInformation>(_customerInformationDal.Get(), Messages.Successful);
        }
        [SecuredOperation("suser,admin,customer.Update,employee")]
        [ValidationAspect(typeof(CustomerInformationValidator))]
        public IResult Update(CustomerInformation customerInformation)
        {
            var result = _customerInformationDal.Update(customerInformation);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }

        [SecuredOperation("suser,admin,customer.Get,employee")]
        public IDataResult<CustomerInformation> GetById(string id)
        {
            return new SuccessDataResult<CustomerInformation>(_customerInformationDal.Get(p => p.Id == id),Messages.Successful);
        }

        private IResult CustomerInformationExists()
        {
            var result = GetAll();
            if (result.Data.Count > 0)
            {
                return new ErrorResult(Messages.CustomerInfırmationAlreadyExists);
            }

            return new SuccessResult(Messages.Successful);
        }

    }
}

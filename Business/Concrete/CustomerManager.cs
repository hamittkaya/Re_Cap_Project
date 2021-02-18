using Business.Abstract;
using Business.Contains;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerService;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerService = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerService.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerService.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerService.Get(c => c.Id == customerId));
        }

        public IResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}

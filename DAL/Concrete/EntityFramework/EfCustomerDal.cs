using Core.DataAccess.EntityFramewrok;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,RentCarContext>,ICustomerDal
    {
    }
}

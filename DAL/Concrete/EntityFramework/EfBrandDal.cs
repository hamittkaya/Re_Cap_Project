using Core.DataAccess.EntityFramewrok;
using DAL.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand,RentCarContext>,IBrandDal
    {
      
    }
}

using Core.DataAccess.EntityFramewrok;
using DAL.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars
                             on r.CarId equals ca.Id
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join cus in context.Customers
                             on r.CustomerId equals cus.Id
                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarId = ca.Id,
                                 Id = r.Id,
                                 CompanyName = cus.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}

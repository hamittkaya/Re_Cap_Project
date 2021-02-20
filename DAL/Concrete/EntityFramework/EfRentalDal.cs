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
                var result = from ren in filter==null? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars
                             on ren.CarId equals ca.Id
                             join br in context.Brands
                             on ren.Id equals br.Id
                             join cu in context.Customers
                             on ren.CustomerId equals cu.Id
                             select new RentalDetailDto
                             {
                                 Id = ren.Id,
                                 CarId = ca.Id,
                                 BrandName = br.BrandName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = ren.RentDate,
                                 ReturnDate = ren.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}

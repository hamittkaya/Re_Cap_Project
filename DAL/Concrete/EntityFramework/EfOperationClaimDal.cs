using Core.DataAccess.EntityFramewrok;
using Core.Entities.Concrete;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim,RentCarContext>,IOperationClaim
    {
    }
}

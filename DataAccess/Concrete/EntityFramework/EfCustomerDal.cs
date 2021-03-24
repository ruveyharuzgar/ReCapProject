using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntitiyRepositoryBase<Customer, ReCapDBContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from user in context.Users
                             join customer in context.Customers
                             on user.Id equals customer.UserId
                             select new CustomerDetailDto
                             {
                                  Id=user.Id,

                                  FirstName=user.FirstName,
                                  LastName=user.LastName,
                                  Email=user.Email,

                                  CompanyName=customer.CompanyName
                             };
                return result.ToList();
            }

        }
    }
}

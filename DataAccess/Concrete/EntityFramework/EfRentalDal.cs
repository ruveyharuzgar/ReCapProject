using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntitiyRepositoryBase<Rental, ReCapDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join user in context.Users
                             on rental.CustomerId equals user.Id
                             select new RentalDetailDto
                             {
                                 Id=car.Id,

                                 ModelName=car.ModelName,
                                 CustomerFirstName=user.FirstName,
                                 CustomerLastName=user.LastName,

                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate

                             };
                return result.ToList();
            }
        }
    }
}
    


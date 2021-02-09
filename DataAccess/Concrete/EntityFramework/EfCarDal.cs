using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntitiyRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 
                                 ModelName = car.ModelName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,

                                 ModelYear=car.ModelYear,
                                 DailyPrice=car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}


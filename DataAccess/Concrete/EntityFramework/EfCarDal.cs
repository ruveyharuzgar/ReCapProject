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
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                   
                                 ModelName = car.ModelName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,

                                 ModelYear=car.ModelYear,
                                 DailyPrice=car.DailyPrice,

                                 Description=car.Description,
                                 ImagePath = (from i in context.CarImages where i.CarId == car.Id select i.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }
        public CarDetailDto GetCarDetailsById(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from car in filter is null ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 Id = car.Id,

                                 ModelName = car.ModelName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,

                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,

                                 Description = car.Description,
                                 ImagePath = (from i in context.CarImages where i.CarId == car.Id select i.ImagePath).FirstOrDefault()
                             };

                return result.FirstOrDefault();
            }
        }
    }
}


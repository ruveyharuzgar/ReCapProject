using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1,ModelYear=2000,DailyPrice=100,Description="Temiz Araba" },
                new Car{Id=2,ModelYear=1960,DailyPrice=350,Description="Vintage Temiz Araba" },
                new Car{Id=3,ModelYear=2018,DailyPrice=180,Description="Temiz Araba" },
                new Car{Id=4,ModelYear=2020,DailyPrice=2000,Description="Sıfır Gibi Araba" },
                new Car{Id=5,ModelYear=2007,DailyPrice=100,Description="Temiz Araba" }
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(i => i.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}

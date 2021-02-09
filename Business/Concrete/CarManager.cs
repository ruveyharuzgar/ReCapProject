using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba bilgisi yüklendi. ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Araba fiyat bilgisi 0'dan küçük olamaz.İşleminizi gerçekleştirilemedi. ");
                Console.ReadLine();
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba bilgisi silindi. ");
            Console.ReadLine();
        }

        public List<Car> GetAll()
        {
            //iş kodları eklenir
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p=>p.BrandId==id);
        }

        public List<Car> GetCarsByColorsId(int id)
        {
            return _carDal.GetAll(p=>p.ColorId==id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araba bilgisi güncellendi. ");
            Console.ReadLine();
        }
    }
}

using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length>2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka bilgisi eklendi.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Marka bilgisi 2 karakterden az olamaz.İşleminiz gerçekleştirilemedi. ");
                Console.ReadLine();
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Marka bilgisi silindi. ");
            Console.ReadLine();
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("Marka bilgisi güncellendi. ");
            Console.ReadLine();
        }
        public List<Brand> GetCarsByBrandId(int id)
        {
            return _brandDal.GetAll(p => p.BrandId == id);
        }

    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brand;
        public InMemoryBrandDal()
        {
            _brand = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Land Rover"},
                new Brand{BrandId=2,BrandName="Mercedes-Benz"},
                new Brand{BrandId=3,BrandName="Renault"},
                new Brand{BrandId=4,BrandName="Ford"},
                new Brand{BrandId=5,BrandName="Seat"},
                new Brand{BrandId=1,BrandName="Volvo"},
                new Brand{BrandId=1,BrandName="Peugeot"},
            };
        }
        public void Add(Brand brand)
        {
            _brand.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brand.SingleOrDefault(b=>b.BrandId==brand.BrandId);
            _brand.Remove(brand);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brand;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetById(int id)
        {
            return _brand.Where(i=>i.BrandId==id).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brand.SingleOrDefault(b=>b.BrandId==brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
        }
    }
}

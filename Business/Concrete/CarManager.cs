using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //[SecuredOperation("admin,product.admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

            //return new ErrorResult(Messages.CarDailyPriceInValid);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("admin,product.admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration:10)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarDetailsListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId==id),Messages.BrandIdListed);
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetCarsByColorsId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId==id));
        }

        [SecuredOperation("admin,product.admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(c => c.Id== id));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>= min && c.DailyPrice<=max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == brandName));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorName == colorName));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameAndColorName(string brandName, string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c =>
                c.BrandName == brandName && c.ColorName == colorName));
        }

        public IDataResult<List<Car>> GetAllCarDetailsByFilter(int brandId, int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList());
        }
    }
}

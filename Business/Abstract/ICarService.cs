using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        //voidlerin hepsini IResult tipinde yaz->operasyonel kodlar(tek tip) 
        //Veri döndürenleri de IDataResult tipinde yaz->aynı zamanda data içeren mesajlı kodlar(iki tip kapsayan)
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorsId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}

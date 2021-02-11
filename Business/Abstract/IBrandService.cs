using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        //voidlerin hepsini IResult tipinde yaz->operasyonel kodlar(tek tip) 
        //Veri döndürenleri de IDataResult tipinde yaz->aynı zamanda data içeren mesajlı kodlar(iki tip kapsayan)
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetCarsByBrandId(int id);


    }
}

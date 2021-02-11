
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        //voidlerin hepsini IResult tipinde yaz->operasyonel kodlar(tek tip) 
        //Veri döndürenleri de IDataResult tipinde yaz->aynı zamanda data içeren mesajlı kodlar(iki tip kapsayan)
        IResult Add(Color colors);
        IResult Delete(Color colors);
        IResult Update(Color colors);
        IDataResult<List<Color>> GetAll();
        IDataResult<List<Color>> GetCarsByColorsId(int id);
    }
}

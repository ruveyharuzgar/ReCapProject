
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        void Add(Color colors);
        void Delete(Color colors);
        void Update(Color colors);
        List<Color> GetAll();
        List<Color> GetCarsByColorsId(int id);
    }
}

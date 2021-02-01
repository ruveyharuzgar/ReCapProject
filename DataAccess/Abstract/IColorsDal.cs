using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorsDal
    {
        List<Colors> GetAll();
        void Add(Colors color);
        void Update(Colors color);
        void Delete(Colors color);
        List<Colors> GetById(int id);
    }
}

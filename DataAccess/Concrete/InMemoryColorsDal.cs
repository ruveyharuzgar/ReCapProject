using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryColorsDal : IColorsDal
    {
        List<Colors> _color;
        public InMemoryColorsDal()
        {
            _color = new List<Colors>
            {
                new Colors{ColorId=1,ColorName="Beyaz"},
                new Colors{ColorId=2,ColorName="Siyah"},
                new Colors{ColorId=3,ColorName="Gri"},
                new Colors{ColorId=4,ColorName="Lacivert"},
                new Colors{ColorId=5,ColorName="Yeşil"},
                new Colors{ColorId=1,ColorName="Kırmızı"}
            };
        }
        public void Add(Colors color)
        {
            _color.Add(color);
        }

        public void Delete(Colors color)
        {
            Colors ColorToDelete;
            ColorToDelete = _color.SingleOrDefault(c => c.ColorId == color.ColorId);
            _color.Remove(ColorToDelete);
        }

        public List<Colors> GetAll()
        {
            return _color;
        }

        public List<Colors> GetById(int id)
        {
            return _color.Where(c=>c.ColorId==id).ToList();
        }

        public void Update(Colors color)
        {
            Colors ColorToUpdate;
            ColorToUpdate = _color.SingleOrDefault(c => c.ColorId == color.ColorId);
            ColorToUpdate.ColorName = color.ColorName;
        }
    }
}

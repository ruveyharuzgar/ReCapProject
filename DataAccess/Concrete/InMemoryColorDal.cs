using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _color;
        public InMemoryColorDal()
        {
            _color = new List<Color>
            {
                new Color{ColorId=1,ColorName="Beyaz"},
                new Color{ColorId=2,ColorName="Siyah"},
                new Color{ColorId=3,ColorName="Gri"},
                new Color{ColorId=4,ColorName="Lacivert"},
                new Color{ColorId=5,ColorName="Yeşil"},
                new Color{ColorId=1,ColorName="Kırmızı"}
            };
        }
        public void Add(Color color)
        {
            _color.Add(color);
        }

        public void Delete(Color color)
        {
            Color ColorToDelete;
            ColorToDelete = _color.SingleOrDefault(c => c.ColorId == color.ColorId);
            _color.Remove(ColorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _color;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetById(int id)
        {
            return _color.Where(c=>c.ColorId==id).ToList();
        }

        public void Update(Color color)
        {
            Color ColorToUpdate;
            ColorToUpdate = _color.SingleOrDefault(c => c.ColorId == color.ColorId);
            ColorToUpdate.ColorName = color.ColorName;
        }
    }
}

using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            if (color.ColorName.Length>3)
            {
                _colorDal.Add(color);
                Console.WriteLine("Renk bilgisi eklendi. ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Renk bilgisi 3 karakterden kısa olamaz.İşleminiz gerçekleştirilemedi. ");
                Console.ReadLine();
            }
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Renk bilgisi silindi. ");
            Console.ReadLine();
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
       }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Renk bilgisi güncellendi. ");
            Console.ReadLine();
        }

        public List<Color> GetCarsByColorsId(int id)
        {
            return _colorDal.GetAll(p => p.ColorId == id);
        }
    }
}

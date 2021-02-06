using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Araba Kiralama Sistemine Hoşgeldiniz... \nSorularınızı yanıtlayalım");
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());


            //brandManager.Add(new Brand { BrandName = "a" });
            //colorManager.Add(new Color { ColorName = "b" });
            brandManager.Add(new Brand { BrandName = "Mercedes-Benz" });
            colorManager.Add(new Color { ColorName = "Kırmızı" });
            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 500, ModelYear = 2016, Description = "Otomatik" });

            foreach (var brand in brandManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(brand.BrandName);
                Console.ReadLine();
            }
            foreach (var color in colorManager.GetCarsByColorsId(1))
            {
                Console.WriteLine(color.ColorName);
                Console.ReadLine();
            }
        }
    }
}

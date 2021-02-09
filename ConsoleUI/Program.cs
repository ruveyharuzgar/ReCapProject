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
            Console.WriteLine("Araba Kiralama Sistemine Hoşgeldiniz...");

            //BrandTest();

            //ColorTest();

            CarTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("  MARKA  -   MODEL - YIL -  RENK - GÜNLÜK ÜCRET ");
            foreach (var c in carManager.GetCarDetails())
            {
                Console.Write(c.BrandName +"   "+c.ModelName+"   "+ c.ModelYear+"   " +c.ColorName+"   "+c.DailyPrice);
                Console.WriteLine();
                Console.ReadLine();
            }
        }



        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetCarsByColorsId(1))
            {
                Console.WriteLine(color.ColorName);
                Console.ReadLine();
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(brand.BrandName);
                Console.ReadLine();
            }
        }
    }
}

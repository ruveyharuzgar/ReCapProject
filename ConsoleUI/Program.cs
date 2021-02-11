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
            var result = carManager.GetCarDetails();

            if (result.Succes==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ModelName+ " Günlük Ücreti: "+car.DailyPrice);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(result.Message);
                Console.ReadKey();
            }
        }



        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetCarsByColorsId(1);

            if (result.Succes == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(result.Message);
                Console.ReadKey();
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetCarsByBrandId(1);

            if (result.Succes == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(result.Message);
                Console.ReadKey();
            }

        }
    }
}

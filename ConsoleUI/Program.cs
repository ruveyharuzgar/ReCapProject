using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Araba Kiralama Sistemine Hoşgeldiniz... \nSorularınızı yanıtlayalım");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            ColorsManager colorsManager = new ColorsManager(new InMemoryColorsDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());

            Console.WriteLine("Kaç Model? Günlük Ücreti Nedir? ");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.ModelYear+" Model ,"+cars.DailyPrice+" TL,"+cars.Description);
                Console.ReadLine();
            }
            Console.WriteLine("Hangi Renkler Var? ");
            foreach (var colors in colorsManager.GetAll())
            {
                Console.WriteLine(colors.ColorName);
                Console.ReadLine();
            }
            Console.WriteLine("Hangi Markalar Var? ");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
                Console.ReadLine();
            }

        }
    }
}

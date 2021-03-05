using Business.Concrete;
using Core.Entities.Concrete;
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

            //CarTest();

            //UserTest();

            //UserAdded();

            //CustomerAdded();

            //RentalAdded();

        }

        private static void RentalAdded()
        {
            DateTime RentDate = new DateTime(2021, 1, 2);
            DateTime ReturnDate = new DateTime(2021, 2, 2);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(
                new Rental
                {

                    CarId = 2,
                    CustomerId = 1,
                    RentDate = RentDate,
                    ReturnDate = ReturnDate

                });
            if (result.Succes == true)
            {
                Console.WriteLine(result.Message);
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine(result.Message);
                Console.ReadLine();
            }
        }

        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(
                new Customer{

                UserId = 2,
                CompanyName = "Öğrenci"

            });
            if (result.Succes == true)
            {
                Console.WriteLine(result.Message);
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine(result.Message);
                Console.ReadLine();
            }
        }

        private static void UserAdded()
        {
            UserManager user = new UserManager(new EfUserDal());
            var result = user.Add(new User
            {
                FirstName = "Oğulcan",
                LastName = "Rüzgar",
                Email = "ogulcan@gmail.com",
                //Password = "123456"
            });

            if (result.Succes == true)
            {
                Console.WriteLine(result.Message);
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine(result.Message);
                Console.ReadLine();
            }
        }

        private static void UserTest()
        {
            UserManager user = new UserManager(new EfUserDal());
            var result = user.GetAll();

            if (result.Succes == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.Email);
                    Console.ReadLine();
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
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

            var result = colorManager.GetCarsByColorId(1);

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

using Business.Concrete;
using Business.Contains;
using DAL.Concrete.EntityFramework;
using DAL.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            CarTest2();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            try
            {
                carManager.Add(new Car { Id = 7, CarName = "aa" });
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        private static void CarTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName+ " " + car.BrandName+ " " + car.ColorName+ " " +car.DailyPrice);
            }
        }
    }
}

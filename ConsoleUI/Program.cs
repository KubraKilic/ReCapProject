using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear+" = " +car.Description);
            }
            Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = "207", Description = "207 Model" };
            carManager.Update(car1);
            Console.WriteLine();
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " = " + car.Description);
            }
            carManager.Delete(car1);
            Console.WriteLine();
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " = " + car.Description);
            }

            Car car2 = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = "207", Description = "207 Model" };
            carManager.Add(car2);
            Console.WriteLine();
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " = " + car.Description);
            }

            Console.WriteLine();

            Console.WriteLine(carManager.GetById(3).ModelYear);
        }
    }
}
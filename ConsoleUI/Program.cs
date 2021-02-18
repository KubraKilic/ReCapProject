using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Car car1 = new Car() { BrandId = 5, ColorId = 7, DailyPrice = 300, Description = "2000 Model", ModelYear = "2000", CarName = "A" };
            carManager.Add(car1);
            //GetCarsByColorId(carManager);
            //GetCarsByBrandId(carManager);
            //ColorGetAll(colorManager);
            //CarGetAll(carManager);
            //DeleteCar(carManager);
            //AddCar(carManager);
            //GetAllCars(carManager);
            //GetCarById(carManager);
        }

        private static void DeleteCar(CarManager carManager)
        {
            Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = "207", Description = "207 Model" };
            carManager.Update(car1);
            Console.WriteLine();
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " = " + car.Description);
            }
            carManager.Delete(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " = " + car.Description);
            }
        }

        private static void AddCar(CarManager carManager)
        {
            Car car2 = new Car {  BrandId = 5, ColorId = 1, DailyPrice = 500, ModelYear = "207", Description = "207 Model", CarName = "E-30" };
            carManager.Add(car2);
        }

        private static void GetCarById(CarManager carManager)
        {
            Console.WriteLine(carManager.GetById(3).CarName);
        }

        private static void GetAllCars(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " = " + car.Description);
            }
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void ColorGetAll(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarGetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " = " + car.Description);
            }
        }
    }
}
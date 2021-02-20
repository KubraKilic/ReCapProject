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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var car1 in carManager.GetProductDetails())
            {
                Console.WriteLine("CarName:{0} --> BrandName:{1} --> ColorName:{2} --> DailyPrice:{3}", car1.CarName, car1.BrandName, car1.ColorName, car1.DailyPrice);
            }

            //GetAllBrands(brandManager);
            //Console.WriteLine();
            //AddBrand(brandManager);
            //Console.WriteLine();
            //UpdateBrand(brandManager);
            //Console.WriteLine();
            //DeleteBrand(brandManager);
            //Console.WriteLine();
            //GetBrandById(brandManager);

            //GetAllColors(colorManager);
            //Console.WriteLine();
            //AddColor(colorManager);
            //Console.WriteLine();
            //UpdateColor(colorManager);
            //Console.WriteLine();
            //DeleteColor(colorManager);
            //Console.WriteLine();
            //GetColorById(colorManager);


            //AddCarWithConditions(carManager);
            //GetCarsByColorId(carManager);
            //GetCarsByBrandId(carManager);



            //Console.WriteLine();
            //AddCar(carManager);
            //Console.WriteLine();

            //Update2(carManager);
            //GetAllCars(carManager);
            //foreach (var car1 in carManager.GetAll())
            //{
            //    Console.WriteLine(car1.DailyPrice);
            //}


            //DeleteCar(carManager);
            //GetCarById(carManager);


        }

        private static void Update2(CarManager carManager)
        {
            Car car = new Car { Id = 1004, DailyPrice = 100, CarName = "ElonMusk", BrandId = 1, ColorId = 2, ModelYear = "2020" };
            carManager.Update2(car);
        }

        private static void DeleteBrand(BrandManager brandManager)
        {
            Brand brand = new Brand { BrandId = 1002, BrandName = "Bentley" };
            brandManager.Delete(brand);
            foreach (var brand1 in brandManager.GetAll())
            {
                Console.WriteLine(brand1.BrandName);
            }
        }

        private static void AddCarWithConditions(CarManager carManager)
        {
            Car car1 = new Car() { BrandId = 5, ColorId = 7, DailyPrice = 300, Description = "2000 Model", ModelYear = "2000", CarName = "A" };
            carManager.Add(car1);
        }

        private static void GetBrandById(BrandManager brandManager)
        {
            Console.WriteLine(brandManager.GetById(2).BrandName);
        }



        private static void UpdateBrand(BrandManager brandManager)
        {
            Brand brand = new Brand { BrandId = 1002, BrandName = "Bentley" };
            brandManager.Update(brand);
            foreach (var brand1 in brandManager.GetAll())
            {
                Console.WriteLine(brand1.BrandName);
            }
        }

        private static void AddBrand(BrandManager brandManager)
        {
            Brand brand = new Brand { BrandName = "Bugatti" };
            brandManager.Add(brand);
            foreach (var brand1 in brandManager.GetAll())
            {
                Console.WriteLine(brand1.BrandName);
            }
        }

        private static void GetAllBrands(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetColorById(ColorManager colorManager)
        {
            Console.WriteLine(colorManager.GetById(1).ColorName);
        }

        private static void DeleteColor(ColorManager colorManager)
        {
            Color color = new Color { ColorId = 8, ColorName = "Turquoise" };
            colorManager.Delete(color);
            foreach (var color1 in colorManager.GetAll())
            {
                Console.WriteLine(color1.ColorName);
            }
        }

        private static void UpdateColor(ColorManager colorManager)
        {
            Color color = new Color { ColorId = 1, ColorName = "Black" };
            colorManager.Update(color);
            foreach (var color1 in colorManager.GetAll())
            {
                Console.WriteLine(color1.ColorName);
            }
        }

        private static void AddColor(ColorManager colorManager)
        {
            Color color = new Color { ColorName = "Orange" };
            colorManager.Add(color);
            foreach (var color1 in colorManager.GetAll())
            {
                Console.WriteLine(color1.ColorName);
            }

        }

        private static void GetAllColors(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
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




    }
}

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
//using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {   
        
        static void Main(string[] args)
        {
            //ShowCarInfo();
            // ShowCarsByBrandId();
            // AddCar(); 
            // DeleteCar();
            //UpdateCar();
            //ShowCarsByColorId();
            //GetAllCars();
            //GetCarById();
            // ShowAllBrands();
            //AddBrand();
            //DeleteBrand();
            //UpdateBrand();
            // GetAllColors();
            // AddColor();
            //DeleteColor();
            //UpdateColor();

        }

        private static void UpdateColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.update(new Color { ColorId = 2, ColorName = "beyaz" });
        }

        private static void DeleteColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.delete(new Color { ColorId = 69 });
        }

        private static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
           colorManager.Add(new Color { ColorName = "Kırmızı" } ); 
        }

        private static void GetAllColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void UpdateBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.update(new Brand { BrandId = 4, BrandName = "AutoSuction" });
        }

        private static void DeleteBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 69 });
        }

        private static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Audi" });
        }

        private static void ShowAllBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetCarById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetCarById(2).Data.CarName + " " + carManager.GetCarById(2).Data.DailyPrice);
        }

        private static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " " + car.ColorName + " " + car.BrandName + " " + car.DailyPrice);
            }
        }

        private static void ShowCarsByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void UpdateCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.update(new Car { CarId = 2, BrandId = 2, ColorId = 4, CarName = "Çökük", ModelYear = 1924, DailyPrice = 200 });
        }

        private static void DeleteCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.delete(new Car { CarId = 3 });
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 3, ColorId = 3, CarName = "Deneme", ModelYear = 2020, DailyPrice = 20000 });
        }

        private static void ShowCarsByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void ShowCarInfo()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0}/{1}/{2}/{3}\n", car.CarName, car.ColorName, car.BrandName, car.DailyPrice);
            }
        }
    }
}

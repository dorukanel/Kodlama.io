
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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }
            EfCarDal efCarDal = new EfCarDal();
            Car car1 = new Car();
            car1.BrandId = 2;
            car1.CarId = 7;
            car1.ColorId = 4;
            car1.DailyPrice = 0;
            car1.ModelYear = 2015;
            car1.Description = "Mercedes Keto";
            efCarDal.Add(car1);
        }
    }
}

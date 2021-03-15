
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
            carManager.delete(new Car {CarId=12, BrandId = 1, ColorId = 1, DailyPrice = 3, Description = "Trash", ModelYear = 1990 });
        }
    }
}

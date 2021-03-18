
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
        // CRUD OPERASYONLARI CALISIYOR denemek için uğraşmadım :)
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}/{1}/{2}/{3}\n",car.CarName,car.ColorName,car.BrandName,car.DailyPrice);
            }
        }
    }
}

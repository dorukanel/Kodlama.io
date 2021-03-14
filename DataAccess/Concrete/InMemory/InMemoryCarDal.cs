using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    /*
    public class InMemoryCarDal :ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            { 
                new Car { CarId = 1, BrandId=1,ColorId=1,ModelYear=2019,DailyPrice = 35000,Description = "Şahin Siyah"},
                new Car { CarId = 2, BrandId = 2, ColorId = 2, ModelYear = 2020, DailyPrice = 400000, Description = "Mercedes AMG Beyaz" },
                new Car { CarId = 3, BrandId = 2, ColorId = 3, ModelYear = 2014, DailyPrice = 200000, Description = "Mercedes Vito Gri" },
                new Car { CarId = 4, BrandId = 2, ColorId = 1, ModelYear = 2019, DailyPrice = 500000, Description = "Mercedes E250 Siyah" },
                new Car { CarId = 5, BrandId = 3, ColorId = 2, ModelYear = 2018, DailyPrice = 250000, Description = "BMW M5 Beyaz" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            car.BrandId = carToUpdate.BrandId;
            car.ColorId = carToUpdate.ColorId;
            car.DailyPrice = carToUpdate.DailyPrice;
            car.Description = carToUpdate.Description;
            car.ModelYear = carToUpdate.ModelYear;

        }
        public List<Car> GetAll()
        {
            return _cars;
        }
    }
    */
}

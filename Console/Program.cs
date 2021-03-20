
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
            //GetRentalDetails();
            // AddRental();
            //DeleteRental(); 
            //updateRental();
            //AddUser();
            //DeleteUser();
            //UpdateUser();
            //GetAllUser();
            // AddCustomer();
            //DeleteCustomer();
            //UpdateCustomer();
            //GetAllCustomers();

        }

        private static void GetAllCustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName + " " + customer.CustomerId + " ");
            }
        }

        private static void UpdateCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.update(new Customer { CustomerId = 3, CompanyName = "SarıKanat" });
            Console.WriteLine(result.Message);
        }

        private static void DeleteCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.delete(new Customer { CustomerId = 2 });
            Console.WriteLine(result.Message);
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { CompanyName = "Sakinler", UserId = 3 });
            Console.WriteLine(result.Message);
        }

        private static void updateRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.update(new Rental { Id = 1, CarId = 2, CustomerId = 1, RentDate = new DateTime(2020, 02, 12), ReturnDate = new DateTime(2021, 03, 12) });
            Console.WriteLine(result.Message);
        }

        private static void DeleteRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.delete(new Rental { Id = 2 });
            Console.WriteLine(result.Message);
        }

        private static void GetAllUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName + " " + user.Email + " " + user.Password);
            }
        }

        private static void UpdateUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.update(new User { Id = 3, Email = "öcüböcü@hotmail.com",FirstName="öcü",LastName="böcü",Password="öcüböcü123" });
            Console.WriteLine(result.Message);
        }

        private static void DeleteUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.delete(new User { Id = 5 });
            Console.WriteLine(result.Message);
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User { Email = "sadık@hotmail.com", FirstName = "sad", LastName = "ık", Password = "sadıksadık" });
            Console.WriteLine(result.Message);
        }

        private static void GetRentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var RentalDtoResults = rentalManager.GetRentDetails();
            if (RentalDtoResults.Success)
            {
                foreach (var rentalDetail in rentalManager.GetRentDetails().Data)
                {
                    Console.WriteLine("{0} {1}  {2}  {3}  {4} {5} ", rentalDetail.BrandName, rentalDetail.ColorName, rentalDetail.CompanyName, rentalDetail.ModelYear, rentalDetail.RentDate, rentalDetail.ReturnDate);
                }
            }
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental { CarId = 2, CustomerId = 2,RentDate=new DateTime(2020,12, 29),ReturnDate= new DateTime(2021,03,20) });
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 2 });
            Console.WriteLine(result.Message);
        }

        private static void UpdateColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
           var result= colorManager.update(new Color { ColorId = 2, ColorName = "beyaz" });
            Console.WriteLine(result.Message);
        }

        private static void DeleteColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.delete(new Color { ColorId = 69 });
            Console.WriteLine(result.Message);
        }

        private static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.Add(new Color { ColorName = "Kırmızı" } );
            Console.WriteLine(result.Message);
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
            var result = brandManager.update(new Brand { BrandId = 4, BrandName = "AutoSuction" });
            Console.WriteLine(result.Message);
        }

        private static void DeleteBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Add(new Brand { BrandId = 69 });
            Console.WriteLine(result.Message);
        }

        private static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Add(new Brand { BrandName = "Audi" });
            Console.WriteLine(result.Message);
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
            var result = carManager.update(new Car { CarId = 2, BrandId = 2, ColorId = 4, CarName = "Çökük", ModelYear = 1924, DailyPrice = 200 });
            Console.WriteLine(result.Message);
        }

        private static void DeleteCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.delete(new Car { CarId = 3 });
            Console.WriteLine(result.Message);
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result =carManager.Add(new Car { BrandId = 3, ColorId = 3, CarName = "Deneme", ModelYear = 2020, DailyPrice = 20000 });
            Console.WriteLine(result.Message);
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

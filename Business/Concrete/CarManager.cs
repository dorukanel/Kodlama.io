﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.DailyPrice<=0 &&car.CarName.Length<=2)
            {
                return new ErrorResult(Messages.InvalidCar);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
                
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>> (_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
            
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
            
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }
    }
}

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
//using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        private ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            //IResult result = BusinessRules.Run(
            //    //  CheckIfAnyImage(car.CarId),
            //    //  CheckIfImageLimitSurpassed(car.CarId)
            //    );
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));

        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }
        /*private IResult CheckIfAnyImage(int carId)
        {
            var result = _carImageService.GetAll(c => c.CarId == carId);
            if (result == null)
            {
                _carImageService.Add(new CarImage
                {
                    ImagePath = "//Resources//Images//DefaultImage.png"
                });
            }
            return new SuccessResult(Messages.DefaultImageAdded);
        }*/
    }
}

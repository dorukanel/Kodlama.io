using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckCarImageCountByCarId(carImage.CarId, 5)
                );
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImage carImage)
        {
            return new SuccessResult(Messages.CarImageUpdated);
        }
        private IResult CheckCarImageCountByCarId(int carId, int imageLimit)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if (result > imageLimit)
            {
                return new ErrorResult(Messages.AmountLimitOfImagesExceeded);
            }
            return new SuccessResult(); //dikkat
        }
    }
}

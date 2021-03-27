using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = CheckReturnDate(rental.CarId);
            if(result.Success)                             // nedense böyle yapınca çalışıyor !result.Success yazarsam ya da result.Success == false yazarsam  
                                                           // çalışmıyor kodun her yerine baktım bir sıkıntı bulamadım ...
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            if(result.Count>0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentDetailDto>> GetRentDetails()
        {
            var result = _rentalDal.GetRentDetails();
            return new SuccessDataResult<List<RentDetailDto>>(result);

        }

        public IResult update(Rental rental)
        {
             _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
            
        }

        public IResult UpdateReturnDate(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId);
            if(result.ReturnDate==null)
            { return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

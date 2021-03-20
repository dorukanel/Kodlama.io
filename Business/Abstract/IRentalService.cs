﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public  interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IResult Add(Rental rental);
        IResult delete(Rental rental);
        IResult update(Rental rental);
        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(Rental rental);
        IDataResult<List<RentDetailDto>> GetRentDetails();
    }
}

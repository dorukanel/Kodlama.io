using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;

namespace DataAccess.Abstract
{
     public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();

    }
}

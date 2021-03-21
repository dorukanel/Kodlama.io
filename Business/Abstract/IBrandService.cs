using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null);
        
        IDataResult<Brand> GetBrandById(int brandId);
        IResult Add(Brand brand);
        IResult delete(Brand brand);
        IResult update(Brand brand );
    }
}

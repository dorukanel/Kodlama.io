using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IResult Add(Customer customer);
        IResult delete(Customer customer);
        IResult update(Customer customer);
    }
}

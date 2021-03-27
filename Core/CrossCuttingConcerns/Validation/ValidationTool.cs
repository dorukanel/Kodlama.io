
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    //tools mostly come with a static keyword for obvious reasons
    public static class ValidationTool
    {                                                   //object hepsinin base i olduğu için hem entity için hem DTO vb için türünü
                                                        // object yaptık.
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<Object>(entity);

            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}

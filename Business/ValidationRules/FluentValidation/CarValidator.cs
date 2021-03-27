using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(1); // Year 2021, Probably the genius behind vehicle industry is considering releasing a single-letter vehicle
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).ExclusiveBetween(1970, DateTime.Now.Year).When(c => c.BrandId == 1 || c.BrandId == 2);

        }

    }
 
}

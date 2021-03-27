using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        //String regex1 = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,20}$";
        public UserValidator()
        {
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
        //private bool IsValidPassword(String password, string regex) bir ara geri döneceğim sana
        //{
        //    
        //}
    }
}

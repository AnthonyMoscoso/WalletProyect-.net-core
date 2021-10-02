using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validations
{
     public class UsersValidator : AbstractValidator<UserDto>
    {
        public UsersValidator()
        {
            RuleFor(w => w.Email).EmailAddress();
            RuleFor(w => w.Password).NotEmpty().NotNull().WithMessage("Password can't be empty");
            RuleFor(w => w.Username).NotEmpty().NotNull().WithMessage("Username can't be empty");
        

        }
    }
}

using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validations
{
    public class ExpenseTypeValidator : AbstractValidator<ExpenseTypeDto>
    {
        public ExpenseTypeValidator()
        {

        }
    }
}

using Entities.DbModels.EF;
using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validations
{
    public class IngressTypeValidator : AbstractValidator<IngressTypeDto>
    {
        public IngressTypeValidator()
        {
            RuleFor(x => x.TypeName).NotEmpty().NotNull().WithMessage("Type name can be empty");
        }
    }
}

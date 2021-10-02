using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validations
{
    public class IngressValidator : AbstractValidator<IngressDto>
    {
        public IngressValidator()
        {
            RuleFor(w => w.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Tittle).NotEmpty().NotNull().WithMessage("Tittle is obligatory");
        }
    }
}

﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invocie.Core.Features.Invoice.Commands.UpdateInvocie
{
    public class UpdateInvocieCommandValidator : AbstractValidator<UpdateInvocieCommand>
    {
        public UpdateInvocieCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{UserName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");

            RuleFor(p => p.EmailAddress)
               .NotEmpty().WithMessage("{EmailAddress} is required.");

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
        }
    }
}

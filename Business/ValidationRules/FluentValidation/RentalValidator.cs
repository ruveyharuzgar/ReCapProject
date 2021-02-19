﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).Must(ReturnDateValue).WithMessage("Araba Teslim Edilmemiş.");
        }

        private bool ReturnDateValue(DateTime? arg)
        {
            return arg.HasValue;
        }
    }
}
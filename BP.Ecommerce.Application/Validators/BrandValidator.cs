﻿using BP.Ecommerce.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.Validators
{
    public class BrandValidator : AbstractValidator<CreateBrandDto>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("No puede ser nulo o vacio");

            RuleFor(x => x.Name)
                .Matches("^[a-zA-Z0-9-]+$")
                .WithMessage("Solo soporta numeros, - y letras");

            RuleFor(x => x.Name)
                .Must(name => WordsValidateUpper(name))
                .WithMessage("Marca debe ser en mayusculas");

        }

        public bool WordsValidateUpper(string word)
        {
            if (word.ToUpper() == word)
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(h => h.Name).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(h => h.Name).MaximumLength(100).WithMessage("Karekter sınırını geçtiniz.");
        }
    }
}

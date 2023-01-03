using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    class ContentValidator:AbstractValidator<Content>
    {
        public ContentValidator()
        {
            RuleFor(c => c.Txt).NotEmpty().WithMessage("Bu alan bo gecilmez");
            RuleFor(c => c.Txt).MaximumLength(1000).WithMessage("Karekter sınırını geçtiniz.");
        }
    }
}

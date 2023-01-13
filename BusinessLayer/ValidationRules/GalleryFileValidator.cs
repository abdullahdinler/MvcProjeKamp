using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class GalleryFileValidator:AbstractValidator<GalleryFile>
    {
        public GalleryFileValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Karekter sınırını aştınız.");
            RuleFor(x => x.Path).NotEmpty().WithMessage("Bu alan boş gecilemez.");
            RuleFor(x => x.Path).MaximumLength(100).WithMessage("Karekter sınırını aştınız.");
        }
    }
}

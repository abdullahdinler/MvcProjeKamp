using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.Name).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(w => w.Name).MaximumLength(50).WithMessage("Karekter sınırını geçtiniz.");
            RuleFor(w => w.SurName).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(w => w.SurName).MaximumLength(50).WithMessage("Karekter sınırını geçtiniz.");
            RuleFor(w => w.About).MaximumLength(150).WithMessage("Karekter sınırını geçtiniz.");
            RuleFor(w=>w.About).Must(w => w != null && w.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");
            RuleFor(w => w.Img).MaximumLength(100).WithMessage("Karekter sınırını geçtiniz.");
            RuleFor(w => w.Mail).MaximumLength(150).WithMessage("Karekter sınırını geçtiniz.");
        }
    }
}

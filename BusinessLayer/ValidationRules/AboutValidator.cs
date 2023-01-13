using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(a => a.Details).MaximumLength(500).WithMessage("Lütfen 500 karekter den az giriniz.");
            RuleFor(a => a.Details2).MaximumLength(500).WithMessage("Lütfen 500 karekter den az giriniz.");
            RuleFor(a=>a.Img).MaximumLength(100).WithMessage("Lütfen 100 karekter den az giriniz.");
            RuleFor(a=>a.Img2).MaximumLength(100).WithMessage("Lütfen 100 karekter den az giriniz.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz.");
            RuleFor(c => c.UserName).MaximumLength(100).WithMessage("Karekter aşımı yaptınız.");
            RuleFor(c=>c.UserMail).MaximumLength(100).WithMessage("Karekter aşımı yaptınız.");
            RuleFor(c=>c.Subject).MaximumLength(100).WithMessage("Karekter aşımı yaptınız.");
            RuleFor(c=>c.Message).MaximumLength(1000).WithMessage("Karekter aşımı yaptınız.");

        }
    }
}

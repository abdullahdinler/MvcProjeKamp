using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class DraftValidator:AbstractValidator<Draft>
    {
        public DraftValidator()
        {
            RuleFor(x => x.SendMail).MaximumLength(50).WithMessage("Girilen email 50 karaekterden uzun.");
            RuleFor(x => x.ReceiverMail).MaximumLength(50).WithMessage("Girilen email 50 karaekterden uzun.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Girilen başlık 100 karaekterden uzun.");
        }
    }
}

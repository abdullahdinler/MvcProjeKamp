using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.SendMail).MaximumLength(50).WithMessage("Mail en fazla 50 karekter olabilir.");
            //RuleFor(x => x.SendMail).EmailAddress().WithMessage("Mail en fazla 50 karekter olabilir.");
            RuleFor(x => x.ReceiverMail).MaximumLength(50).WithMessage("Mail en fazla 50 karekter olabilir.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Başlık en fazla 100 karekter icerebilir.");
            RuleFor(x => x.Subject).MinimumLength(30).WithMessage("Mesajnız en az 30 karekter olması lazım.");
        }
    }
}

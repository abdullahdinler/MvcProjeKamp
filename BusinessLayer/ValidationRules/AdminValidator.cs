using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Karekter aşımı geçekleşti");
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("Karekter aşımı geçekleşti");
            RuleFor(x => x.Role).MaximumLength(1).WithMessage("Karekter aşımı geçekleşti");
        }
    }
}

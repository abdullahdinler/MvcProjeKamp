using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            //Kategori ismini boş geçilmez yaptık ve uyarı mesajı verdik.
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategory adını boş geçemezsiniz.");
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("Kategori ismi 50 karekterden büyük olamaz.");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Acıklamayı boş geçemezsiniz.");
            RuleFor(c=>c.Description).MaximumLength(200).WithMessage("Açıklama 200 karekterden büyük olamaz.");
        }
    }
}

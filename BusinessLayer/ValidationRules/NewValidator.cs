using BlogProject1.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.ValidationRules
{
    public class NewValidator : AbstractValidator<New>
    {
        public NewValidator()
        {
            RuleFor(x => x.NewTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.NewContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(x => x.NewImage).NotEmpty().WithMessage("Blog görseli boş geçilemez");
            RuleFor(x => x.NewTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın");
            RuleFor(x => x.NewTitle).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha fazla veri girişi yapın");
        }
    }

}

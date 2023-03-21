using BlogProject1.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görseli boş geçilemez");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha fazla veri girişi yapın");
        }
    }
}

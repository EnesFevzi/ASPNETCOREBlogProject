using BlogProject1.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.ValidationRules
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator()
        {
            RuleFor(x => x.VideoTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.VideoContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            //RuleFor(x => x.VideoImage).NotEmpty().WithMessage("Blog görseli boş geçilemez");
            RuleFor(x => x.VideoTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın");
            RuleFor(x => x.VideoTitle).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha fazla veri girişi yapın");
        }
    }
}

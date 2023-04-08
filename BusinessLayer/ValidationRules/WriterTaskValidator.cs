using BlogProject1.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.ValidationRules
{
    public class WriterTaskValidator : AbstractValidator<WriterTask>
    {
        public WriterTaskValidator()
        {
            RuleFor(x => x.TaskName).NotEmpty().WithMessage("Görev Adı Boş Geçilemez");
            RuleFor(x => x.TaskDescription).NotEmpty().WithMessage("Görev Açıklması Boş Geçilemez");
            RuleFor(x => x.TaskName).MaximumLength(50).WithMessage("Görev Adı En Fazla 50 Karakter Olmalıdır");
            RuleFor(x => x.TaskName).MinimumLength(2).WithMessage("Görev Adı En Az 2 Karakter Olmalıdır");
        }

    }
}

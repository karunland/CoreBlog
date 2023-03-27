using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Cannot be longer than 150 characters");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Cannot be shorther than 5 characters");
             
        }
    }
}

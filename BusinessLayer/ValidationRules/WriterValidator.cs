using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail cannot be empty");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Please enter at least two characters");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Please enter maximum of 50 characters");

        }
    }
}

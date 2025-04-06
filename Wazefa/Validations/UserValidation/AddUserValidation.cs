using FluentValidation;
using System.Text.RegularExpressions;
using Wazefa.Core.DTOs.UserDtos;

namespace API.Validations.UserValidation
{
    public class AddUserValidation : AbstractValidator<AddUserRequest>
    {
        public AddUserValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("gfs")
                .NotNull().WithMessage("315r")
                .Must((u, e) =>
                {
                    if (e.Contains(" "))
                        return false;
                    return true;
                });
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("asf")
                .NotNull().WithMessage("qwed")
                .Matches(new Regex(@"^(?!.*\d_)(?!.*_\d)[a-zA-Z0-9ء-ي ]+$"))
                .WithMessage("fas");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("zxbq")
                .NotNull().WithMessage("vbz");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("vzc")
                .NotNull().WithMessage("fasxz");
        }
    }
}

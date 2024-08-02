using FluentValidation;
using System.Text.RegularExpressions;
using Wazefa.DTOs.UserDtos;

namespace API.Validations.UserValidation
{
    public class AddUserValidation : AbstractValidator<AddUserRequest>
    {
        public AddUserValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("")
                .NotNull().WithMessage("")
                .Must((u, e) =>
                {
                    if (e.Contains(" "))
                        return false;
                    return true;
                });
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("")
                .NotNull().WithMessage("")
                .Matches(new Regex(@"^(?!.*\d_)(?!.*_\d)[a-zA-Z0-9ء-ي ]+$"))
                .WithMessage("");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("")
                .NotNull().WithMessage("");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("")
                .NotNull().WithMessage("");
        }
    }
}

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
                .NotEmpty().WithMessage("Email is required")
                .NotNull().WithMessage("Email is required")
                .Must((obj, name) =>
                {
                    if (string.IsNullOrWhiteSpace(name))
                        return false;
                    return true;
                }).WithMessage("First name is required");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .NotNull().WithMessage("First name is required")
                .Matches(new Regex(@"^(?!.*\d_)(?!.*_\d)[a-zA-Z0-9ء-ي ]+$"))
                .WithMessage("First name is Arabic or English only");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .NotNull().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password length more than 7 characters");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .NotNull().WithMessage("Phone number is required");
        }
    }
}

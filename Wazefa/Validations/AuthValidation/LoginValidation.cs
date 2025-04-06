using FluentValidation;
using Wazefa.Core.DTOs.AuthDtos;

namespace API.Validations.AuthValidation
{
    public class LoginValidation : AbstractValidator<LoginRequestDto>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email).Must((obj, em) =>
            {
                if (string.IsNullOrEmpty(em) || string.IsNullOrWhiteSpace(em))
                    return false;
                return true;
            }).WithMessage("Email is Required");
            RuleFor(x => x.Password).Must((obj, pa) =>
            {
                if (string.IsNullOrEmpty(pa) || string.IsNullOrWhiteSpace(pa))
                    return false;
                return true;
            }).WithMessage("Password is Required")
            .MinimumLength(8).WithMessage("Password length more than 7 characters");

        }
    }
}

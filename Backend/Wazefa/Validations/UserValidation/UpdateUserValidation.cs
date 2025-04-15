using FluentValidation;
using Wazefa.Core.DTOs.UserDtos;

namespace API.Validations.UserValidation
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required").NotEmpty().WithMessage("Id Required");
            Include(new AddUserValidation());
        }
    }
}

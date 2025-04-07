using FluentValidation;
using Wazefa.Core.DTOs.AppointmentDtos;

namespace API.Validations.AppointmentValidation
{
    public class AddAppointmentValidation : AbstractValidator<AddAppointmentRequest>
    {
        public AddAppointmentValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name is required")
                .Must((obj, name) =>
                {
                    if (string.IsNullOrWhiteSpace(name))
                        return false;
                    return true;
                }).WithMessage("Name is required");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Enter job description")
                .NotNull().WithMessage("Enter job description");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company is required")
                .NotNull().WithMessage("Company is required");

        }
    }
}

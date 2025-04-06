using API.Validations.AppointmentValidation;
using FluentValidation;
using Wazefa.Core.DTOs.AppointmentDtos;

namespace API.Validations.AppointmentValidation
{
    public class UpdateAppointmentValidation : AbstractValidator<UpdateAppointmentRequest>
    {
        public UpdateAppointmentValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required").NotEmpty().WithMessage("Id Required");
            Include(new AddAppointmentValidation());
        }
    }
}

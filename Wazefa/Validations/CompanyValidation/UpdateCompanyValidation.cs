using FluentValidation;
using Wazefa.Core.DTOs.CompanyDtos;

namespace API.Validations.CompanyValidation
{
    public class UpdateCompanyValidation : AbstractValidator<UpdateCompanyRequest>
    {
        public UpdateCompanyValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required").NotEmpty().WithMessage("Id Required");
            Include(new AddCompanyValidation());
        }
    }
}

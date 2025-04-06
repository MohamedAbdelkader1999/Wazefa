using FluentValidation;
using Wazefa.Core.DTOs.CompanyDtos;

namespace API.Validations.CompanyValidation
{
    public class AddCompanyValidation : AbstractValidator<AddCompanyRequest>
    {
        public AddCompanyValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name is required")
                .Must((u, e) =>
                {
                    if (e.Contains(" "))
                        return false;
                    return true;
                }).WithMessage("Name is required");
            RuleFor(x => x.AboutCompany)
                .NotEmpty().WithMessage("Enter informations about Company")
                .NotNull().WithMessage("Enter informations about Company");
            
        }
    }
}

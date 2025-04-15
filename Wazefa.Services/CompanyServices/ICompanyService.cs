using Wazefa.Core.DTOs.CompanyDtos;
using Wazefa.Core.DTOs.ResponseResultDtos;

namespace Wazefa.Services.CompanyServices
{
    public interface ICompanyService
    {
        Task<ResponseResultDto<CompanyResponse>> AddAsync(AddCompanyRequest dto, string userId);
        Task<ResponseResultDto<bool>> DeleteAsync(string id);
        Task<ResponseResultDto<CompanyResponse>> GetByIdAsync(string id);
        Task<ResponseResultDto<CompanyResponse>> UpdateAsync(UpdateCompanyRequest dto, string userId);
    }
}

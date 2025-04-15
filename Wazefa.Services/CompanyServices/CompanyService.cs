using AutoMapper;
using Wazefa.Core.DTOs.CompanyDtos;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.Entities;
using Wazefa.Data;

namespace Wazefa.Services.CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResultDto<CompanyResponse>> AddAsync(AddCompanyRequest dto, string userId)
        {
            ResponseResultDto<CompanyResponse> response = new();
            Company entity = _mapper.Map<Company>(dto);
            entity.CreatedByUserId = userId;
            Company? result = await _unitOfWork.companyRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return response.MappingResponse(_mapper.Map<CompanyResponse>(result));
        }
        public async Task<ResponseResultDto<CompanyResponse>> GetByIdAsync(string id)
        {
            ResponseResultDto<CompanyResponse> response = new ();
            Company? company = await _unitOfWork.companyRepository.GetByIdAsync(id);
            if (company == null)
                return response.MappingResponse();
            return response.MappingResponse(_mapper.Map<CompanyResponse>(company));
        }
        public async Task<ResponseResultDto<CompanyResponse>> UpdateAsync(UpdateCompanyRequest dto, string userId)
        {
            ResponseResultDto<CompanyResponse> response = new ();
            Company? entity = await _unitOfWork.companyRepository.GetByIdAsync(dto.Id);
            User? loggedInUser = await _unitOfWork.userRepository.GetByIdAsync(userId);
            if (entity == null || loggedInUser == null)
                return response.MappingResponse();
            _mapper.Map(dto, entity);
            entity.ModificationDate = DateTime.UtcNow;
            Company updatedEntity = _unitOfWork.companyRepository.Update(entity);
            return response.MappingResponse(_mapper.Map<CompanyResponse>(entity));
        }
        public async Task<ResponseResultDto<bool>> DeleteAsync(string id)
        {
            ResponseResultDto<bool> response = new ();
            Company? company = await _unitOfWork.companyRepository.GetByIdAsync(id);
            if (company == null)
                return response.MappingResponse();
            _unitOfWork.companyRepository.Delete(company);
            bool isDeleted = await _unitOfWork.SaveAsync() > 0 ? true : false;
            return response.MappingResponse(isDeleted);
        }
    }
}

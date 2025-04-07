using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<ResponseResultDto<CompanyResponseDto>> Add(AddCompanyRequest dto)
        {
            ResponseResultDto<CompanyResponseDto> response = new();
            Company entity = _mapper.Map<Company>(dto);
            Company? result = await _unitOfWork.companyRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return response.MappingResponse(_mapper.Map<CompanyResponseDto>(result));
        }
    }
}

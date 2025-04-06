using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.DTOs.CompanyDtos;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Data;

namespace Wazefa.Services.CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ResponseResultDto<CompanyResponseDto>> Add(AddCompanyRequest dto)
        {

        }
    }
}

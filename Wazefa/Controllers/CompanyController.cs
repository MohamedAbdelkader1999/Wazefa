using API.Validations.CompanyValidation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wazefa.Core.DTOs.CompanyDtos;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Services.CompanyServices;

namespace API.Controllers
{
    [Authorize]
    public class CompanyController : AppBaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost, Route(nameof(Add)), ProducesResponseType(typeof(CompanyResponse), 200)]
        public async Task<IActionResult> Add(AddCompanyRequest dto)
        {
            AddCompanyValidation validations = new ();
            ValidationResult validationResult = validations.Validate(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            ResponseResultDto<CompanyResponse> result = await _companyService.AddAsync(dto,UserId);
            return Ok(result);
        }
        //[HttpGet, Route(nameof(GetPagedList)), ProducesResponseType(typeof(CompanyResponse), 200)]
        //public async Task<IActionResult> GetPagedList(string id)
        //{
        //    ResponseResultDto<CompanyResponse> result = await _companyService.GetByIdAsync(id);
        //    return Ok(result);
        //}
        [HttpGet, Route(nameof(GetById)), ProducesResponseType(typeof(CompanyResponse), 200)]
        public async Task<IActionResult> GetById(string id)
        {
            ResponseResultDto<CompanyResponse> result = await _companyService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPatch, Route(nameof(Update)), ProducesResponseType(typeof(CompanyResponse), 200)]
        public async Task<IActionResult> Update(UpdateCompanyRequest dto)
        {
            UpdateCompanyValidation validations = new ();
            ValidationResult validationResult = validations.Validate(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            ResponseResultDto<CompanyResponse> result = await _companyService.UpdateAsync(dto,UserId);
            return Ok(result);
        }
        [HttpDelete, Route(nameof(Delete)), ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete(string id)
        {
            ResponseResultDto<bool> result = await _companyService.DeleteAsync(id);
            return Ok(result);
        }
    }
}

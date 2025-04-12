using API.Validations.AppointmentValidation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.DTOs.AppointmentDtos;
using Wazefa.Services.AppointmentServices;

namespace API.Controllers
{
    [Authorize]
    public class AppointmentController : AppBaseController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost,, Route(nameof(Add)), ProducesResponseType(typeof(AppointmentResponse), 200)]
        public async Task<IActionResult> Add(AddAppointmentRequest dto)
        {
            AddAppointmentValidation validations = new AddAppointmentValidation();
            ValidationResult validationResult = validations.Validate(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            ResponseResultDto<AppointmentResponse> result = await _appointmentService.AddAsync(dto,UserId);
            return Ok(result);
        }
        //[HttpGet, Route(nameof(GetPagedList)), ProducesResponseType(typeof(AppointmentResponse), 200)]
        //public async Task<IActionResult> GetPagedList(string id)
        //{
        //    ResponseResultDto<AppointmentResponse> result = await _appointmentService.GetByIdAsync(id);
        //    return Ok(result);
        //}
        [HttpGet, Route(nameof(GetById)), ProducesResponseType(typeof(AppointmentResponse), 200)]
        public async Task<IActionResult> GetById(string id)
        {
            ResponseResultDto<AppointmentResponse> result = await _appointmentService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPatch, Route(nameof(Update)), ProducesResponseType(typeof(AppointmentResponse), 200)]
        public async Task<IActionResult> Update(UpdateAppointmentRequest dto)
        {
            UpdateAppointmentValidation validations = new UpdateAppointmentValidation();
            ValidationResult validationResult = validations.Validate(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            ResponseResultDto<AppointmentResponse> result = await _appointmentService.UpdateAsync(dto,UserId);
            return Ok(result);
        }
        [HttpDelete, Route(nameof(Delete)), ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete(string id)
        {
            ResponseResultDto<bool> result = await _appointmentService.DeleteAsync(id);
            return Ok(result);
        }
    }
}

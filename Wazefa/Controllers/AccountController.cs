using API.Validations.AuthValidation;
using API.Validations.UserValidation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wazefa.Core.DTOs.AuthDtos;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.DTOs.UserDtos;
using Wazefa.Services.AuthServices;
using Wazefa.Services.UserServices;

namespace API.Controllers
{
    public class AccountController : AppBaseController
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost, Route(nameof(SignIn)), ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<IActionResult> SignIn(LoginRequestDto dto)
        {
            LoginValidation validations = new LoginValidation();
            ValidationResult validationResult = validations.Validate(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            ResponseResultDto<LoginResponseDto> result = await _authService.SignInAsync(dto);
            return Ok(result);
        }
        
    }
}

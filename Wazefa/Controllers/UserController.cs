using API.Validations.UserValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.DTOs.UserDtos;
using Wazefa.Services.UserService;

namespace API.Controllers
{
    public class UserController : AppBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, Route(nameof(Add)), ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<IActionResult> Add(AddUserRequest dto)
        {
            AddUserValidation validations = new AddUserValidation();
            ValidationResult validationResult = validations.Validate(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            ResponseResultDto<UserResponse> result = await _userService.AddAsync(dto);
            return Ok(result);
        }
        [HttpPost, Route(nameof(GetById)), ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<IActionResult> GetById(string id)
        {
            ResponseResultDto<UserResponse> result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }
    }
}

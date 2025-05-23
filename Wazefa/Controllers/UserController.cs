﻿using API.Validations.UserValidation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.DTOs.UserDtos;
using Wazefa.Services.UserServices;

namespace API.Controllers
{
    public class UserController : AppBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost,Authorize(Roles ="Admin"), Route(nameof(Add)), ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<IActionResult> Add(AddUserRequest dto)
        {
            AddUserValidation validations = new ();
            ValidationResult validationResult = validations.Validate(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            ResponseResultDto<UserResponse> result = await _userService.AddAsync(dto);
            return Ok(result);
        }
        [HttpGet, Route(nameof(GetPagedList)), ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<IActionResult> GetPagedList(string id)
        {
            ResponseResultDto<UserResponse> result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet, Route(nameof(GetById)), ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<IActionResult> GetById(string id)
        {
            ResponseResultDto<UserResponse> result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPatch, Route(nameof(Update)), ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<IActionResult> Update(UpdateUserRequest dto)
        {
            UpdateUserValidation validations = new ();
            ValidationResult validationResult = validations.Validate(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            ResponseResultDto<UserResponse> result = await _userService.UpdateAsync(dto);
            return Ok(result);
        }
        [HttpDelete, Route(nameof(Delete)), ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete(string id)
        {
            ResponseResultDto<bool> result = await _userService.DeleteAsync(id);
            return Ok(result);
        }
    }
}

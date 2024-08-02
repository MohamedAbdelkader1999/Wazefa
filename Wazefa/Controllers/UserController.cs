using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wazefa.DTOs.UserDtos;
using Wazefa.Infrastructure.Services.UserService;

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

            return Ok(await _userService.AddAsync(dto));
        }
    }
}

using API.Validations.AuthValidation;
using API.Validations.UserValidation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
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
            LoginValidation validations = new ();
            ValidationResult validationResult = validations.Validate(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            (ResponseResultDto<LoginResponseDto> model, string userId) result = await _authService.SignInAsync(dto);
            if (result.model.StatusCode == (int)HttpStatusCode.OK)
            {
                var claims = new List<Claim>
                    {
                        new Claim(type: ClaimTypes.Name,value: result.model.Data.UserName),
                        new Claim(type: ClaimTypes.NameIdentifier,value: result.userId)
                    };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
                    {
                        IsPersistent = dto.RememberMe,
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(2),
                    });
            }
            return Ok(result.model);
        }
        [HttpPost,Authorize, Route(nameof(SignOut))]
        public async new Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
        [HttpGet, Authorize, Route(nameof(GetUser))]
        public IActionResult GetUser()
        {
            return Ok(User.Claims.Where(x => !x.Type.EndsWith("nameidentifier")).Select(x => new UserClaim(x.Type, x.Value)).ToList());
        }
    }
}

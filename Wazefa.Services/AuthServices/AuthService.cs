using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.ConfigurationDtos;
using Wazefa.Core.DTOs.AuthDtos;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.Entities;
using Wazefa.Data;
using Wazefa.Services.Shared;

namespace Wazefa.Services.AuthServices
{
    public class AuthService(IUnitOfWork unitOfWork, IOptions<AuthSettings> authSetting,ISharedService sharedService) : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly AuthSettings _authSetting = authSetting.Value;

        public async Task<(ResponseResultDto<LoginResponseDto> dto,string userId)> SignInAsync(LoginRequestDto dto)
        {
            ResponseResultDto<LoginResponseDto> response = new()
            {
                Data = new()
            };
            User? user = await _unitOfWork.userRepository.SingleOrDefaultAsync(x=>x.Email == dto.Email);
            
            if (user == null || sharedService.VerifyPassword(user,dto.Password) == PasswordVerificationResult.Failed)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = "Email or password is not correct";
                return (response,string.Empty);
            }
            //validate if this user can authenticate or not

            //JwtSecurityToken generatedToken = await this.GenerateToken(user, DateTime.UtcNow.AddDays(Convert.ToDouble(_authSetting.ExpireAfterDays)));
            //string tokenString = new JwtSecurityTokenHandler().WriteToken(generatedToken);
            response.Data.UserName = user.FirstName + " " + user.LastName;
            response.Data.Role = user.Role.Name;
            // if refresh token is in DB
            //if (user.RefreshToken is not null)
            //    response.Data.RefreshToken = user.RefreshToken.Token;
            //// else generate new refresh token and save it in DB 
            //else
            //{
            //    JwtSecurityToken refreshToken = this.GenerateRefreshToken(user);
            //    string generatedRefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken);
            //    response.Data.RefreshToken = generatedRefreshToken;
            //    user.RefreshToken = new ()
            //    {
            //        CreationDate = DateTime.UtcNow,
            //        ExpiredOn = refreshToken.ValidTo,
            //        Token = generatedRefreshToken,
            //        UserId = user.Id
            //    };
            //    await _unitOfWork.SaveAsync();
            //}
            return (response.MappingResponse(response.Data),user.Id);
        }
        public async Task<JwtSecurityToken> GenerateToken(User user, DateTime expireOn)
        {
            UserRole? userRole = await _unitOfWork.userRoleRepository.SingleOrDefaultAsync(x=>x.Id == user.RoleId);
            List<Claim> claims =
                        [
                         new (ClaimTypes.Name , user.FirstName + " " + user.LastName),
                         new (ClaimTypes.NameIdentifier , user.Id.ToString()),
                         new (ClaimTypes.Email , user.Email ?? ""),
                         new (ClaimTypes.Role , userRole.Name)
                        ];
            var key = Encoding.ASCII.GetBytes(_authSetting.Key);
            JwtSecurityToken tokenOptions = new (
                claims: claims,
                expires: expireOn,
                signingCredentials: new (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
            return tokenOptions;
        }
        public JwtSecurityToken GenerateRefreshToken(User user)
        {
            List<Claim> claims =
                        [
                         new (ClaimTypes.NameIdentifier,user.Id.ToString())
                        ];
            var key = Encoding.ASCII.GetBytes(_authSetting.Key);
            JwtSecurityToken tokenOptions = new(
                claims: claims,
                expires: null,
                signingCredentials: new (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
            return tokenOptions;
        }
    }
}

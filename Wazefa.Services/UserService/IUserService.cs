using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.DTOs.UserDtos;
using Wazefa.Core.Entities;

namespace Wazefa.Services.UserService
{
    public interface IUserService
    {
        Task<ResponseResultDto<UserResponse>> AddAsync(AddUserRequest dto);
        Task<ResponseResultDto<UserResponse>> GetByIdAsync(string id);
    }
}

using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.DTOs.UserDtos;
using Wazefa.Core.Entities;

namespace Wazefa.Services.UserServices
{
    public interface IUserService
    {
        Task<ResponseResultDto<UserResponse>> AddAsync(AddUserRequest dto);
        Task<ResponseResultDto<bool>> DeleteAsync(string id);
        Task<ResponseResultDto<UserResponse>> GetByIdAsync(string id);
        Task<ResponseResultDto<UserResponse>> UpdateAsync(UpdateUserRequest dto);
    }
}

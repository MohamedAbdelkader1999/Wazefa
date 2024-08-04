using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.DTOs.UserDtos;
using Wazefa.Core.Entities;

namespace Wazefa.Services.UserService
{
    public interface IUserService
    {
        Task<UserResponse?> AddAsync(AddUserRequest dto);
        Task<bool> DeleteAsync(string id);
        Task<UserResponse?> GetByIdAsync(string id);
        Task<UserResponse?> UpdateAsync(UpdateUserRequest dto);
    }
}

using Wazefa.Core.Entities;
using Wazefa.Core.Interfaces;
using Wazefa.DTOs.UserDtos;

namespace Wazefa.Infrastructure.Services.UserService
{
    public interface IUserService : IBaseService<User, AddUserRequest, UpdateUserRequest, UserResponse, string>
    {

    }
}

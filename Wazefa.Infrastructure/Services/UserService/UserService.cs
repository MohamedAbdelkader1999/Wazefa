using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;
using Wazefa.Core.Interfaces;
using Wazefa.DTOs.UserDtos;

namespace Wazefa.Infrastructure.Services.UserService
{
    public class UserService : BaseService<User, AddUserRequest, UpdateUserRequest, UserResponse, string>, IUserService
    {
        private readonly IRepository<User, string> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IRepository<User, string> repository, IMapper mapper) : base(repository, mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }
    }
}

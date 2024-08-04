using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.DTOs.UserDtos;
using Wazefa.Core.Entities;
using Wazefa.Data;

namespace Wazefa.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseResultDto<UserResponse>> AddAsync(AddUserRequest dto)
        {
            ResponseResultDto<UserResponse> response = new ResponseResultDto<UserResponse>();
            User? addedUser = await _unitOfWork.userRepository.AddAsync(_mapper.Map<User>(dto));
            await _unitOfWork.SaveAsync();
            return response.MappingResponse(_mapper.Map<UserResponse>(addedUser));
        }
        public async Task<ResponseResultDto<UserResponse>> GetByIdAsync(string id)
        {
            ResponseResultDto<UserResponse> response = new ResponseResultDto<UserResponse>();
            User? user = await _unitOfWork.userRepository.GetByIdAsync(id);
            if (user == null)
                return response.MappingResponse((int)HttpStatusCode.NotFound);

            return response.MappingResponse(_mapper.Map<UserResponse>(user));
        }
    }
}

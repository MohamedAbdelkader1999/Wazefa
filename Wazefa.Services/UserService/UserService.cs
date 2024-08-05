using AutoMapper;
using Azure;
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
using Grpc.Core;

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
        public async Task<UserResponse?> AddAsync(AddUserRequest dto)
        {
            User? addedUser = await _unitOfWork.userRepository.AddAsync(_mapper.Map<User>(dto));
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UserResponse>(addedUser);
        }
        public async Task<UserResponse?> GetByIdAsync(string id)
        {
            User? user = await _unitOfWork.userRepository.GetByIdAsync(id);
            if (user == null)
                return null;

            return _mapper.Map<UserResponse>(user);
        }
        public async Task<UserResponse?> UpdateAsync(UpdateUserRequest dto)
        {

            User? user = await _unitOfWork.userRepository.GetByIdAsync(dto.Id);
            if (user == null)
                return null;
            user = _mapper.Map<User>(dto);
            User updatedUser = _unitOfWork.userRepository.Update(user);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UserResponse>(user);
        }
        public async Task<bool> DeleteAsync(string id)
        {
            User? user = await _unitOfWork.userRepository.GetByIdAsync(id);
            //if (user == null)
            //    return null;
            _unitOfWork.userRepository.Delete(user);
            bool isDeleted = await _unitOfWork.SaveAsync() > 0 ? true :false;
            return isDeleted;
        }
    }
}

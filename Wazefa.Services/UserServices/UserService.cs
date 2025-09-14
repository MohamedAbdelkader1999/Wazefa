using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
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
using Wazefa.Services.Shared;

namespace Wazefa.Services.UserServices
{
    public class UserService(IUnitOfWork unitOfWork, IMapper mapper,ISharedService sharedService) : IUserService
    {
        public async Task<ResponseResultDto<UserResponse>> AddAsync(AddUserRequest dto)
        {
            ResponseResultDto<UserResponse> response = new();
            User userToAdd = mapper.Map<User>(dto);
            userToAdd.Password = sharedService.HashPassword(userToAdd,dto.Password);
            await unitOfWork.userRepository.AddAsync(userToAdd);
            await unitOfWork.SaveAsync();
            return response.MappingResponse(mapper.Map<UserResponse>(userToAdd));
        }
        //public async Task<ResponseResultDto<UserResponse>> GetPagedAsync(string id)
        //{
        //    var response = new ResponseResultDto<UserResponse>();
        //    IEnumerable<User> userList = await _unitOfWork.userRepository.GetList();
        //    if (user == null)
        //        return response.MappingResponse();
        //    return response.MappingResponse(_mapper.Map<UserResponse>(user));
        //}
        public async Task<ResponseResultDto<UserResponse>> GetByIdAsync(string id)
        {
            ResponseResultDto<UserResponse> response = new();
            User? user = await unitOfWork.userRepository.GetByIdAsync(id);
            if (user == null)
                return response.MappingResponse();
            return response.MappingResponse(mapper.Map<UserResponse>(user));
        }
        public async Task<ResponseResultDto<UserResponse>> UpdateAsync(UpdateUserRequest dto)
        {
            ResponseResultDto<UserResponse> response = new();
            User? user = await unitOfWork.userRepository.GetByIdAsync(dto.Id);
            if (user == null)
                return response.MappingResponse();
            mapper.Map(dto, user);
            user.ModificationDate = DateTime.UtcNow;
            User updatedUser = unitOfWork.userRepository.Update(user);
            return response.MappingResponse(mapper.Map<UserResponse>(updatedUser));
        }
        public async Task<ResponseResultDto<bool>> DeleteAsync(string id)
        {
            ResponseResultDto<bool> response = new();
            User? user = await unitOfWork.userRepository.GetByIdAsync(id);
            if (user == null)
                return response.MappingResponse();
            unitOfWork.userRepository.Delete(user);
            bool isDeleted = await unitOfWork.SaveAsync() > 0 ? true : false;
            return response.MappingResponse(isDeleted);
        }
    }
}

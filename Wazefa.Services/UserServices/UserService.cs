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

namespace Wazefa.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<ResponseResultDto<UserResponse>> AddAsync(AddUserRequest dto)
        {
            var response = new ResponseResultDto<UserResponse>();
            User userToAdd = _mapper.Map<User>(dto);
            var result = await _userManager.CreateAsync(userToAdd, dto.Password);
            if(await _roleManager.FindByIdAsync(dto.RoleName) == null)
                await _roleManager.CreateAsync(new IdentityRole { Name = dto.RoleName});
            await _userManager.AddToRoleAsync(userToAdd, dto.RoleName);
            return response.MappingResponse(_mapper.Map<UserResponse>(userToAdd));
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
            var response = new ResponseResultDto<UserResponse>();
            User? user = await _unitOfWork.userRepository.GetByIdAsync(id);
            if (user == null)
                return response.MappingResponse();
            return response.MappingResponse(_mapper.Map<UserResponse>(user));
        }
        public async Task<ResponseResultDto<UserResponse>> UpdateAsync(UpdateUserRequest dto)
        {
            var response = new ResponseResultDto<UserResponse>();
            User? user = await _userManager.FindByIdAsync(dto.Id);
            if (user == null)
                return response.MappingResponse();
            _mapper.Map(dto, user);
            user.ModificationDate = DateTime.UtcNow;
            IdentityResult updatedUser = await _userManager.UpdateAsync(user);
            return response.MappingResponse(_mapper.Map<UserResponse>(user));
        }
        public async Task<ResponseResultDto<bool>> DeleteAsync(string id)
        {
            var response = new ResponseResultDto<bool>();
            User? user = await _unitOfWork.userRepository.GetByIdAsync(id);
            if (user == null)
                return response.MappingResponse();
            _unitOfWork.userRepository.Delete(user);
            bool isDeleted = await _unitOfWork.SaveAsync() > 0 ? true : false;
            return response.MappingResponse(isDeleted);
        }
    }
}

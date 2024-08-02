using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;
using Wazefa.DTOs.UserDtos;

namespace Wazefa.Infrastructure.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AddUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User,UserResponse>()
                //.ForMember(x=>x.FullName,xx=>xx.MapFrom(x=>x.FirstName + " " + x.LastName))
                ;    
        }
    }
}

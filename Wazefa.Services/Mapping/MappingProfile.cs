using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.DTOs.UserDtos;
using Wazefa.Core.Entities;

namespace Wazefa.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserRequest, User>().ForMember(x=>x.UserName,xx=>xx.MapFrom(c=>c.Email));
            CreateMap<UpdateUserRequest, User>()
                .ForMember(x=>x.Id ,xx=>xx.MapFrom(c=>c.Id))
                .ForMember(x => x.UserName, xx => xx.MapFrom(c => c.Email));
            CreateMap<User, UserResponse>()
                .ForMember(x => x.FullName, xx => xx.MapFrom(x => x.FirstName + " " + x.LastName))
                ;
        }
    }
}

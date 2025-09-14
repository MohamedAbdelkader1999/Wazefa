using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.DTOs.AppointmentDtos;
using Wazefa.Core.DTOs.CompanyDtos;
using Wazefa.Core.DTOs.UserDtos;
using Wazefa.Core.Entities;

namespace Wazefa.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserRequest, User>();
            CreateMap<UpdateUserRequest, User>()
                .ForMember(x=>x.Id ,xx=>xx.MapFrom(c=>c.Id));
            CreateMap<User, UserResponse>()
                .ForMember(x => x.FullName, xx => xx.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(x => x.Role, xx => xx.MapFrom(x => x.Role.Name))
                ;
            //Company
            CreateMap<AddCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Company>();
            CreateMap<Company, CompanyResponse>();
            //Appointment
            CreateMap<AddAppointmentRequest, Appointment>();
            CreateMap<UpdateAppointmentRequest, Appointment>();
            CreateMap<Appointment, AppointmentResponse>()
                .ForMember(x => x.CompanyName, xx => xx.MapFrom(x => x.Company.Name))
                ;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.DTOs.AppointmentDtos;
using Wazefa.Core.DTOs.ResponseResultDtos;

namespace Wazefa.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<ResponseResultDto<AppointmentResponse>> AddAsync(AddAppointmentRequest dto, string userId);
        Task<ResponseResultDto<bool>> DeleteAsync(string id);
        Task<ResponseResultDto<AppointmentResponse>> GetByIdAsync(string id);
        Task<ResponseResultDto<AppointmentResponse>> UpdateAsync(UpdateAppointmentRequest dto, string userId);
    }
}

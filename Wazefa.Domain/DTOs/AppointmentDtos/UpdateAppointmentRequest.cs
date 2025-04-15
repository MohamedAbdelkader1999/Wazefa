using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.AppointmentDtos
{
    public class UpdateAppointmentRequest : AddAppointmentRequest
    {
        public required string Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.AppointmentDtos
{
    public class AddAppointmentRequest
    {
        public required string Name { get; set; }
        public required string CompanyId { get; set; }
        public required string Description { get; set; }
    }
}

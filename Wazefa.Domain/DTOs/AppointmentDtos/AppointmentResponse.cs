using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.AppointmentDtos
{
    public class AppointmentResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
    }
}

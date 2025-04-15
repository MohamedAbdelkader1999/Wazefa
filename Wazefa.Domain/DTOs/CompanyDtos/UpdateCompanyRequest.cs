using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.CompanyDtos
{
    public class UpdateCompanyRequest : AddCompanyRequest
    {
        public required string Id { get; set; }
        
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.CompanyDtos
{
    public class AddCompanyRequest
    {
        public required string Name { get; set; }
        public string Logo { get; set; }
        public required string AboutCompany { get; set; }
    }
}

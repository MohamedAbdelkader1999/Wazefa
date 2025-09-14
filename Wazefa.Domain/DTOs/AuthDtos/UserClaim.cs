using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.AuthDtos
{
    public class UserClaim(string _type, string _value)
    {
        public string Type { get; set; } = _type;
        public string Value { get; set; } = _value;
    }
}

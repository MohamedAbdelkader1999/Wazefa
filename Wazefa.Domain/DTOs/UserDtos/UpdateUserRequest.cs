using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.UserDtos
{
    public class UpdateUserRequest : AddUserRequest
    {
        public string Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.UserDtos
{
    public class AddUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? SecondaryPhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string RoleName { get; set; }

    }
}

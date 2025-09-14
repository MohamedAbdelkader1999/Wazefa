using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.Entities
{
    //[Table(nameof(User))]
    public class User 
    {
        public User()
        {
            Appointments = new HashSet<Appointment>();

        }
        public string Id { get; set; } 
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModificationDate { get; set; }
        public string? CompanyId { get; set; }
        public string RoleId { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual RefreshToken RefreshToken { get; set; }
        public virtual UserRole Role { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Domain.Entities
{
    [Table(nameof(User))]
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public virtual RefreshToken RefreshToken { get; set; }
    }
}

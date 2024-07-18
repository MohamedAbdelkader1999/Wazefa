using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Domain.Entities
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}

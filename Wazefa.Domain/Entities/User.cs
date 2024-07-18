using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Domain.Entities
{
    [Table("Users")]
    public class User : User<int>
    {
        public string FullName { get; set; }
    }
    public class User<T> : IdentityUser<T> where T : IEquatable<T>
    {
        public string FullName { get; set; }
    }
}

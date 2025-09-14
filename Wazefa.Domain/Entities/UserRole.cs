using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.Entities
{
    public class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();

        }
        public string Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

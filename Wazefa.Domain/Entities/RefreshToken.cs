using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Domain.Entities
{
    [Table(nameof(RefreshToken))]
    public class RefreshToken
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public DateTime Create { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}

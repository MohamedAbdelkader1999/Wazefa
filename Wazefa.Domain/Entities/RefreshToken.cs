using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.Entities
{
    [Table(nameof(RefreshToken))]
    public class RefreshToken
    {
        public string Id { get; set; }
        public required string Token { get; set; }
        public required string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExpiredOn { get; set; } = null;
        public virtual User User { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.Entities
{
    public class Appointment
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string CompanyId { get; set; }
        public required string Description { get; set; }
        public required DateTime CreationDate { get; set; } = DateTime.Now;
        public required string CreatedByUserId { get; set; }
        public DateTime? ModificationDate { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual Company Company { get; set; }

    }
}

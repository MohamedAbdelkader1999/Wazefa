using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Domain.Entities
{
    [Table(nameof(Skill))]
    public class Skill
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

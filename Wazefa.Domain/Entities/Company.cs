using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.Entities
{
    public class Company
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public string Logo { get; set; }
        public required string AboutCompany { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        /// Number of Employees in the company calculated automatically from the number of accounts operating at this company
    }
}

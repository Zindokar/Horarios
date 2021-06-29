using System;
using System.Collections.Generic;

#nullable disable

namespace HorariosBack.Models
{
    public partial class Person
    {
        public Person()
        {
            JobContracts = new HashSet<JobContract>();
            PersonAudits = new HashSet<PersonAudit>();
        }

        public uint Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<JobContract> JobContracts { get; set; }
        public virtual ICollection<PersonAudit> PersonAudits { get; set; }
    }
}

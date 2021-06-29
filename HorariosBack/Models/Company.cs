using System;
using System.Collections.Generic;

#nullable disable

namespace HorariosBack.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyAudits = new HashSet<CompanyAudit>();
            JobContracts = new HashSet<JobContract>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CompanyAudit> CompanyAudits { get; set; }
        public virtual ICollection<JobContract> JobContracts { get; set; }
    }
}

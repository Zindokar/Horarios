using System;
using System.Collections.Generic;

#nullable disable

namespace HorariosBack.Models
{
    public partial class JobContract
    {
        public JobContract()
        {
            JobContractAudits = new HashSet<JobContractAudit>();
            Schedules = new HashSet<Schedule>();
        }

        public uint Person { get; set; }
        public uint Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public float? SalaryPerHour { get; set; }
        public string Position { get; set; }

        public virtual Company CompanyNavigation { get; set; }
        public virtual Person PersonNavigation { get; set; }
        public virtual ICollection<JobContractAudit> JobContractAudits { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}

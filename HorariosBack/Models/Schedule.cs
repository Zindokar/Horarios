using System;
using System.Collections.Generic;

#nullable disable

namespace HorariosBack.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            ScheduleAudits = new HashSet<ScheduleAudit>();
        }

        public uint Id { get; set; }
        public uint Company { get; set; }
        public uint Person { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public virtual JobContract JobContract { get; set; }
        public virtual ICollection<ScheduleAudit> ScheduleAudits { get; set; }
    }
}

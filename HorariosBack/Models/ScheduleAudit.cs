using System;
using System.Collections.Generic;

#nullable disable

namespace HorariosBack.Models
{
    public partial class ScheduleAudit
    {
        public uint Id { get; set; }
        public DateTime CurrentFinishDate { get; set; }
        public uint Schedule { get; set; }
        public DateTime PreviousStartDate { get; set; }
        public DateTime CurrentStartDate { get; set; }
        public DateTime PreviousFinishDate { get; set; }
        public uint PreviousCompany { get; set; }
        public uint CurrentCompany { get; set; }
        public uint PreviousPerson { get; set; }
        public uint CurrentPerson { get; set; }
        public DateTime ChangedDate { get; set; }

        public virtual Schedule ScheduleNavigation { get; set; }
    }
}

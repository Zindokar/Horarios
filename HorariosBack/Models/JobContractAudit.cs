using System;
using System.Collections.Generic;

#nullable disable

namespace HorariosBack.Models
{
    public partial class JobContractAudit
    {
        public uint Id { get; set; }
        public uint Compnay { get; set; }
        public uint Person { get; set; }
        public uint PreviousPerson { get; set; }
        public uint CurrentPerson { get; set; }
        public uint PreviousCompany { get; set; }
        public uint CurrentCompany { get; set; }
        public DateTime PreviousStartDate { get; set; }
        public DateTime CurrentStartDate { get; set; }
        public float PreviousSalaryPerHour { get; set; }
        public float CurrentSalaryPerHour { get; set; }
        public string PreviousPosition { get; set; }
        public string CurrentPosition { get; set; }
        public DateTime ChangedDate { get; set; }

        public virtual JobContract JobContract { get; set; }
    }
}

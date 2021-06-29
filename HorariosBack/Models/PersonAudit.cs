using System;
using System.Collections.Generic;

#nullable disable

namespace HorariosBack.Models
{
    public partial class PersonAudit
    {
        public uint Id { get; set; }
        public uint Person { get; set; }
        public string PreviousUsername { get; set; }
        public string CurrentUsername { get; set; }
        public bool ChangedPass { get; set; }
        public string PreviousName { get; set; }
        public string CurrentName { get; set; }
        public string PreviousMail { get; set; }
        public string CurrentMail { get; set; }
        public DateTime ChangedDate { get; set; }

        public virtual Person PersonNavigation { get; set; }
    }
}

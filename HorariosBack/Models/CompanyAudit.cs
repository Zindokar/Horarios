using System;
using System.Collections.Generic;

#nullable disable

namespace HorariosBack.Models
{
    public partial class CompanyAudit
    {
        public uint Id { get; set; }
        public uint Company { get; set; }
        public string PreviousName { get; set; }
        public string CurrentName { get; set; }
        public DateTime ChangedDate { get; set; }

        public virtual Company CompanyNavigation { get; set; }
    }
}

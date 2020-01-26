using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblReportingManager
    {
        public int RepMgrID { get; set; }
        public string ReportingManager { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual tblJobRole tblJobRole { get; set; }
    }
}

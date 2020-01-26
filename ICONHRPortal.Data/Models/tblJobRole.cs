using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblJobRole
    {
        public tblJobRole()
        {
            this.PerformanceReviewSettings = new List<PerformanceReviewSetting>();
            this.tblPerformanceReviewSettings = new List<tblPerformanceReviewSetting>();
            this.tblReportingManagers = new List<tblReportingManager>();
        }

        public int JobRoleID { get; set; }
        public string JobRole { get; set; }
        public Nullable<int> DeptID { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual lkpDepartment lkpDepartment { get; set; }
        public virtual ICollection<PerformanceReviewSetting> PerformanceReviewSettings { get; set; }
        public virtual ICollection<tblPerformanceReviewSetting> tblPerformanceReviewSettings { get; set; }
        public virtual ICollection<tblReportingManager> tblReportingManagers { get; set; }
    }
}

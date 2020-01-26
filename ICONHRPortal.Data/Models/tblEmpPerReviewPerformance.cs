using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblEmpPerReviewPerformance
    {
        public tblEmpPerReviewPerformance()
        {
            this.tblEmpPerReviewSegments = new List<tblEmpPerReviewSegment>();
        }

        public int EmpReviewID { get; set; }
        public Nullable<int> RepMgrID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public int PerformanceReviewID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> SharetoManager { get; set; }
        public virtual tblEmployeeDetail tblEmployeeDetail { get; set; }
        public virtual tblPerformanceReviewSetting tblPerformanceReviewSetting { get; set; }
        public virtual List<tblEmpPerReviewSegment> tblEmpPerReviewSegments { get; set; }
    }
}

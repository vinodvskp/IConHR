using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblMgrPerReviewPerformance
    {
        public tblMgrPerReviewPerformance()
        {
            this.tblMgrPerReviewSegments = new List<tblMgrPerReviewSegment>();
        }

        public int MgrReviewID { get; set; }
        public Nullable<int> RepMgrID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public int PerformanceReviewID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual tblEmployeeDetail tblEmployeeDetail { get; set; }
        public virtual tblPerformanceReviewSetting tblPerformanceReviewSetting { get; set; }
        public virtual List<tblMgrPerReviewSegment> tblMgrPerReviewSegments { get; set; }
    }
}

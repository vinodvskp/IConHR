using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class EmpMgrPerReviewSegment
    {
        public int PerformanceSegmentID { get; set; }
        public int SegmentID { get; set; }
        public Nullable<int> PerformanceID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public virtual tblPerformanceSegment tblPerformanceSegment { get; set; }
    }
}

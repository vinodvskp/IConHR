using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblMgrPerReviewSegment
    {
        public tblMgrPerReviewSegment()
        {
            this.tblMgrPerReviewRatings = new List<tblMgrPerReviewRating>();
        }

        public int MgrReviewSegmentID { get; set; }
        public int PerformanceSegmentID { get; set; }
        public Nullable<int> MgrReviewID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual tblMgrPerReviewPerformance tblMgrPerReviewPerformance { get; set; }
        public virtual List<tblMgrPerReviewRating> tblMgrPerReviewRatings { get; set; }
    }
}

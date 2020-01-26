using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblMgrPerReviewRating
    {
        public int MgrPerReviewRatingID { get; set; }
        public int MgrReviewSegmentID { get; set; }
        public int PerformanceQuestionID { get; set; }
        public Nullable<int> ScoreID { get; set; }
        public string Answer { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual tblMgrPerReviewSegment tblMgrPerReviewSegment { get; set; }
        public virtual tblPerformaceSegmentQuestion tblPerformaceSegmentQuestion { get; set; }
    }
}

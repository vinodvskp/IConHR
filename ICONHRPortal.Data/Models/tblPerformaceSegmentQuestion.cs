using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblPerformaceSegmentQuestion
    {
        public tblPerformaceSegmentQuestion()
        {
            this.tblEmpPerReviewRatings = new List<tblEmpPerReviewRating>();
            this.tblMgrPerReviewRatings = new List<tblMgrPerReviewRating>();
        }

        public int PerformanceQuestionID { get; set; }
        public Nullable<int> PerformanceSegmentID { get; set; }
        public string Question { get; set; }
        public string HelpText { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public virtual List<tblEmpPerReviewRating> tblEmpPerReviewRatings { get; set; }
        public virtual List<tblMgrPerReviewRating> tblMgrPerReviewRatings { get; set; }
        public virtual tblPerformanceSegment tblPerformanceSegment { get; set; }
    }
}

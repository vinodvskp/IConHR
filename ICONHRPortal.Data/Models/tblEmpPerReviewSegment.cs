using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblEmpPerReviewSegment
    {
        public tblEmpPerReviewSegment()
        {
            this.tblEmpPerReviewRatings = new List<tblEmpPerReviewRating>();
        }

        public int EmpReviewSegmentID { get; set; }
        public int SegmentID { get; set; }
        public Nullable<int> EmpReviewID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual tblEmpPerReviewPerformance tblEmpPerReviewPerformance { get; set; }
        public virtual List<tblEmpPerReviewRating> tblEmpPerReviewRatings { get; set; }
        public virtual tblPerformanceSegment tblPerformanceSegment { get; set; }
    }
}

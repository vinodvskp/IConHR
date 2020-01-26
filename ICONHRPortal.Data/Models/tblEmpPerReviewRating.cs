using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblEmpPerReviewRating
    {
        public int EmpPerReviewRatingID { get; set; }
        public int EmpReviewSegmentID { get; set; }
        public int QuestionID { get; set; }
        public Nullable<int> ScoreID { get; set; }
        public string Answer { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual tblEmpPerReviewSegment tblEmpPerReviewSegment { get; set; }
        public virtual tblPerformaceSegmentQuestion tblPerformaceSegmentQuestion { get; set; }
    }
}

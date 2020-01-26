using System;
using System.Collections.Generic;

namespace ICONHRPortal.Model
{
    public partial class EmpPerReviewRatingModel
    {
        public int EmpMgrPerReviewRatingID { get; set; }
        public int EmpMgrReviewSegmentID { get; set; }
        public int QuestionID { get; set; }
        public Nullable<int> ScoreID { get; set; }
        public string Answer { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ICONHRPortal.Model
{
    public partial class EmpPerReviewSegmentModel
    {
        public EmpPerReviewSegmentModel()
        {
            this.tblEmpPerReviewRatings = new List<EmpPerReviewRatingModel>();
        }

        public int EmpMgrReviewSegmentID { get; set; }
        public int SegmentID { get; set; }
        public Nullable<int> EmpMgrReviewID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public List<EmpPerReviewRatingModel> tblEmpPerReviewRatings { get; set; }
    }
}

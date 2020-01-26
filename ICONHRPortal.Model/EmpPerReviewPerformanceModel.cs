using System;
using System.Collections.Generic;

namespace ICONHRPortal.Model
{
    public partial class EmpPerReviewPerformanceModel
    {
        public EmpPerReviewPerformanceModel()
        {
            this.tblEmpPerReviewSegments = new List<EmpPerReviewSegmentModel>();
        }

        public int EmpReviewID { get; set; }
        public Nullable<int> RepMgrID { get; set; }
        public string ManagerName { get; set; }
        public Nullable<int> EmpID { get; set; }
        public string EmployeeName { get; set; }
        public int PerformanceReviewID { get; set; }
        public string ReviewTitle { get; set; }
        public decimal? TotalScore { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public List<EmpPerReviewSegmentModel> tblEmpPerReviewSegments { get; set; }
    }
}

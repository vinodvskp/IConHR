using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class MgrPerReviewPerformanceModel
    {
        public MgrPerReviewPerformanceModel()
        {
            this.tblMgrPerReviewSegments = new List<MgrPerReviewSegmentModel>();
        }
        public int MgrReviewID { get; set; }
        public Nullable<int> RepMgrID { get; set; }
        public string ManagerName { get; set; }
        public Nullable<int> EmpID { get; set; }
        public string EmployeeName { get; set; }
        public int PerformanceReviewID { get; set; }
        public string ReviewTitle { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public decimal? TotalScore { get; set; }
        public  List<MgrPerReviewSegmentModel> tblMgrPerReviewSegments { get; set; }
    }
}

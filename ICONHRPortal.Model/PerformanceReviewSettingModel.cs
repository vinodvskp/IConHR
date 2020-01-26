using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class PerformanceReviewSettingModel
    {
        public PerformanceReviewSettingModel()
        {
            this.tblPerformanceScores = new List<PerformanceScoreModel>();
            this.tblPerformanceSegments = new List<PerformanceSegmentModel>();
        }
        public int PerformanceReviewID { get; set; }
        public string ReviewTitle { get; set; }
        public Nullable<System.DateTime> ReviewCompletionDate { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string CompanyName { get; set; }
        public Nullable<long> LocationID { get; set; }
        public string LocationName { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public string JobRoleName { get; set; }
        public Nullable<int> EmploymentTypeID { get; set; }
        public string EmploymentTypeName { get; set; }
        public Nullable<int> LengthOfService { get; set; }
        public Nullable<int> OverallScoreID { get; set; }
        public Nullable<int> SegmentID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public List<PerformanceScoreModel> tblPerformanceScores { get; set; }
        public List<PerformanceSegmentModel> tblPerformanceSegments { get; set; }
    }
}

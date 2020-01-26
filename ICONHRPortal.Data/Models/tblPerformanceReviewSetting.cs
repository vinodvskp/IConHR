using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblPerformanceReviewSetting
    {
        public tblPerformanceReviewSetting()
        {
            this.tblEmployeePerformances = new List<tblEmployeePerformance>();
            this.tblEmpPerReviewPerformances = new List<tblEmpPerReviewPerformance>();
            this.tblManagerPerformances = new List<tblManagerPerformance>();
            this.tblMgrPerReviewPerformances = new List<tblMgrPerReviewPerformance>();
            this.tblPerformanceScores = new List<tblPerformanceScore>();
            this.tblPerformanceSegments = new List<tblPerformanceSegment>();
        }

        public int PerformanceReviewID { get; set; }
        public string ReviewTitle { get; set; }
        public Nullable<System.DateTime> ReviewCompletionDate { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<long> LocationID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public Nullable<int> EmploymentTypeID { get; set; }
        public Nullable<int> LengthOfService { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual lkpDepartment lkpDepartment { get; set; }
        public virtual lkpEmploymentType lkpEmploymentType { get; set; }
        public virtual lkpLocation lkpLocation { get; set; }
        public virtual tblCompanyDetail tblCompanyDetail { get; set; }
        public virtual ICollection<tblEmployeePerformance> tblEmployeePerformances { get; set; }
        public virtual ICollection<tblEmpPerReviewPerformance> tblEmpPerReviewPerformances { get; set; }
        public virtual tblJobRole tblJobRole { get; set; }
        public virtual List<tblManagerPerformance> tblManagerPerformances { get; set; }
        public virtual List<tblMgrPerReviewPerformance> tblMgrPerReviewPerformances { get; set; }
        public virtual List<tblPerformanceScore> tblPerformanceScores { get; set; }
        public virtual List<tblPerformanceSegment> tblPerformanceSegments { get; set; }
    }
}

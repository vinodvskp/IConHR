using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpDepartment
    {
        public lkpDepartment()
        {
            this.PerformanceReviewSettings = new List<PerformanceReviewSetting>();
            this.tblEmployeeJobDetails = new List<tblEmployeeJobDetail>();
            this.tblJobRoles = new List<tblJobRole>();
            this.tblPerformanceReviewSettings = new List<tblPerformanceReviewSetting>();
            this.tblPlanners = new List<tblPlanner>();
        }

        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual ICollection<PerformanceReviewSetting> PerformanceReviewSettings { get; set; }
        public virtual ICollection<tblEmployeeJobDetail> tblEmployeeJobDetails { get; set; }
        public virtual ICollection<tblJobRole> tblJobRoles { get; set; }
        public virtual ICollection<tblPerformanceReviewSetting> tblPerformanceReviewSettings { get; set; }
        public virtual ICollection<tblPlanner> tblPlanners { get; set; }
    }
}

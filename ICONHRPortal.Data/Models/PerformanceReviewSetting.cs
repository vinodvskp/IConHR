using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class PerformanceReviewSetting
    {
        public long PerformanceReviewID { get; set; }
        public string ReviewTitle { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public long LocationID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public Nullable<int> EmployementTypeID { get; set; }
        public Nullable<int> SpecificEmployeeID { get; set; }
        public Nullable<int> ExcludeEmployeeID { get; set; }
        public Nullable<int> LegthofServiceID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDAte { get; set; }
        public virtual lkpDepartment lkpDepartment { get; set; }
        public virtual lkpEmploymentType lkpEmploymentType { get; set; }
        public virtual lkpLocation lkpLocation { get; set; }
        public virtual tblJobRole tblJobRole { get; set; }
    }
}

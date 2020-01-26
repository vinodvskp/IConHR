using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblPlanner
    {
        public int PlannerID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<long> LocationId { get; set; }
        public string PlannedEventName { get; set; }
        public Nullable<int> PlannerCategoryID { get; set; }
        public Nullable<System.DateTime> PlannedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual lkpDepartment lkpDepartment { get; set; }
        public virtual lkpLocation lkpLocation { get; set; }
        public virtual lkpPlannerCategoryType lkpPlannerCategoryType { get; set; }
    }
}

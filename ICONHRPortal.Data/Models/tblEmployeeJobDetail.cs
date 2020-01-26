using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblEmployeeJobDetail
    {
        public int JobID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<int> DeptID { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public Nullable<int> RepMgrID { get; set; }
        public Nullable<long> LocationID { get; set; }
        public Nullable<System.DateTime> EmpStartDate { get; set; }
        public Nullable<int> JobTypeID { get; set; }
        public Nullable<int> ContractedHours { get; set; }
        public virtual lkpDepartment lkpDepartment { get; set; }
        public virtual lkpJobType lkpJobType { get; set; }
        public virtual lkpLocation lkpLocation { get; set; }
        public virtual tblEmployeeDetail tblEmployeeDetail { get; set; }
    }
}

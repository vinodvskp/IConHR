using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class EmployeeTimesheet
    {
        public int TimesheetID { get; set; }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Project { get; set; }
        public string Task { get; set; }
        public string Details { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> TotalHours { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Notes { get; set; }
        public Nullable<int> Approver { get; set; }
        public Nullable<bool> isApproved { get; set; }
        public Nullable<bool> IsSubmited { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class EmployeeTimesheetModel
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
        public int Approver { get; set; }
        public Nullable<bool> isApproved { get; set; }
        public Nullable<bool> IsSubmited { get; set; }
    }
}

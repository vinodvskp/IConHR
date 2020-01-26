using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class tblEmployeeJobDetailsModel
    {
        public int JobID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<int> DeptID { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public Nullable<int> RepMgrID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<System.DateTime> EmpStartDate { get; set; }
        public Nullable<int> JobTypeID { get; set; }
        public Nullable<int> ContractedHours { get; set; }
       
    }
}

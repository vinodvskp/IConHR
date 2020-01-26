using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpEmployeeRole
    {
        public lkpEmployeeRole()
        {
            this.tblEmployeeDetails = new List<tblEmployeeDetail>();
        }

        public int EmpRoleID { get; set; }
        public string EmpRole { get; set; }
        public virtual ICollection<tblEmployeeDetail> tblEmployeeDetails { get; set; }
    }
}

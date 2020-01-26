using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblAdministratorSetting
    {
        public long AdministratorSettingID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> AssignedEmployeeID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public virtual tblCompanyDetail tblCompanyDetail { get; set; }
        public virtual tblEmployeeDetail tblEmployeeDetail { get; set; }
    }
}

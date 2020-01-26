using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class AdministratorSettingModel
    {
        public long AdministratorSettingID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string AssignedEmployeeName { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string JobRole { get; set; }
        public string EmploymentTypeDesc { get; set; }
        public string LengthOfService { get; set; }
        public Nullable<int> AssignedEmployeeID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}

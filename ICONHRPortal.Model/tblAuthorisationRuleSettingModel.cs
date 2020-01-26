using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{

    public  class tblAuthorisationRuleSettingModel
    {
        public long AuthorisationRuleSettingsID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<bool> InUse { get; set; }
        public string RuleName { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string JobRoleID { get; set; }
        public string JobRoleName { get; set; }
        public string EmploymentTypeID { get; set; }
        public string EmploymentTypeName { get; set; }
        public string SpecificEmployeeID { get; set; }
        public string SpecificEmployeeName { get; set; }
        public string ExcludeEmployeeID { get; set; }
        public string ExcludeEmployeeName { get; set; }
        public string ApproverID { get; set; }
        public string ApproverName { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}

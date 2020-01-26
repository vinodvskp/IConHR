using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public  class tblEmployeeSettingModel
    {
        public long EmployeeSettingsID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<bool> ManagerCanSeeEmployeeSalary { get; set; }
        public Nullable<bool> EmployeeCanSeeTheirOwnSalary { get; set; }
        public Nullable<bool> AllowEmployeeToUploadPhoto { get; set; }
        public Nullable<bool> ManagerCanSeeEmployeeContactDetail { get; set; }
        public Nullable<bool> ManagerCanUploadDocument { get; set; }
        public Nullable<bool> TopFactsAboutOurCompanyReport { get; set; }
        public Nullable<bool> ManagerCanSeeEmployeeDOB { get; set; }
        public Nullable<bool> Appraisal { get; set; }
        public Nullable<bool> Benefits { get; set; }
        public Nullable<bool> CPD { get; set; }
        public Nullable<bool> DrivingLicence { get; set; }
        public Nullable<bool> Qualification { get; set; }
        public Nullable<bool> Training { get; set; }
        public Nullable<bool> Vehicle { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
      //  public virtual tblCompanyDetail tblCompanyDetail { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblCompanySetting
    {
        public long CompanySettingID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public byte[] UploadLogo { get; set; }
        public Nullable<bool> ApplyThemeColour { get; set; }
        public string CompanyStatement { get; set; }
        public string Industry { get; set; }
        public string DateFormat { get; set; }
        public string MonthOrWeek { get; set; }
        public string BaseCurrency { get; set; }
        public string NI_SSNValidation { get; set; }
        public Nullable<bool> Resetpassword { get; set; }
        public Nullable<int> ProbationPeriod { get; set; }
        public Nullable<int> PasswordExpiryDuration { get; set; }
        public Nullable<int> SessionTimeOutPeriod { get; set; }
        public Nullable<int> EmployeeAccessID { get; set; }
        public Nullable<int> ManagerAccessID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public virtual tblCompanyDetail tblCompanyDetail { get; set; }
    }
}

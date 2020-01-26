using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblEmailSettings
    {
        public long EmailSettingsID { get; set; }
        public int CompanyID { get; set; }
        public Nullable<bool> DailyAdminEmail { get; set; }
        public Nullable<bool> WeeklyManagerEmail { get; set; }
        public Nullable<bool> WeeklyEmployeeEmail { get; set; }
        public Nullable<bool> HolidayEmailReminder { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public virtual tblCompanyDetail tblCompanyDetail { get; set; }
    }
}

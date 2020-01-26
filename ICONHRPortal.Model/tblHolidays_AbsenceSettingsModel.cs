using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class tblHolidays_AbsenceSettingsModel
    {
        public long Holidays_AbsenceSettingID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<long> LocationID { get; set; }
        public Nullable<int> NormalWorkingHours { get; set; }
        public Nullable<int> DefaultWorkPatternID { get; set; }
        public Nullable<int> FullTimeHours { get; set; }
        public Nullable<int> MaximumDurationofConsecutiveAnnualLeave { get; set; }
        public Nullable<int> MaxHolidayCarryOverDays { get; set; }
        public Nullable<int> MaxHolidayCarryOverHours { get; set; }
        public Nullable<bool> HolidayYearID { get; set; }
        public Nullable<long> DefaultPublicHolidayTemplateID { get; set; }
        public Nullable<bool> TotalHolidayEntitlementIncludePUblicHolidays { get; set; }
        public Nullable<bool> HolidayReturnToWorkForm { get; set; }
        public Nullable<bool> AuthoriseHolidaysFromEmail { get; set; }
        public Nullable<bool> LOSRuleID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}

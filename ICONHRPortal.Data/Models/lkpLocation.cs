using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpLocation
    {
        public lkpLocation()
        {
            this.PerformanceReviewSettings = new List<PerformanceReviewSetting>();
            this.tblEmployeeJobDetails = new List<tblEmployeeJobDetail>();
            this.tblHolidays_AbsenceSettings = new List<tblHolidays_AbsenceSettings>();
            this.tblLocalizationSettings = new List<tblLocalizationSetting>();
            this.tblPerformanceReviewSettings = new List<tblPerformanceReviewSetting>();
            this.tblPlanners = new List<tblPlanner>();
        }

        public long LocationId { get; set; }
        public string Location { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public virtual ICollection<PerformanceReviewSetting> PerformanceReviewSettings { get; set; }
        public virtual ICollection<tblEmployeeJobDetail> tblEmployeeJobDetails { get; set; }
        public virtual ICollection<tblHolidays_AbsenceSettings> tblHolidays_AbsenceSettings { get; set; }
        public virtual ICollection<tblLocalizationSetting> tblLocalizationSettings { get; set; }
        public virtual ICollection<tblPerformanceReviewSetting> tblPerformanceReviewSettings { get; set; }
        public virtual ICollection<tblPlanner> tblPlanners { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblCompanyDetail
    {
        public tblCompanyDetail()
        {
            this.tblAdministratorSettings = new List<tblAdministratorSetting>();
            this.tblAuthorisationRuleSettings = new List<tblAuthorisationRuleSetting>();
            this.tblCompanySettings = new List<tblCompanySetting>();
            this.tblDomainDetails = new List<tblDomainDetail>();
            this.tblEmailSettings = new List<tblEmailSettings>();
            this.tblEmployeeDetails = new List<tblEmployeeDetail>();
            this.tblEmployeeSettings = new List<tblEmployeeSetting>();
            this.tblHolidays_AbsenceSettings = new List<tblHolidays_AbsenceSettings>();
            this.tblLocalizationSettings = new List<tblLocalizationSetting>();
            this.tblPerformanceReviewSettings = new List<tblPerformanceReviewSetting>();
        }

        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanySize { get; set; }
        public bool IsActive { get; set; }
        public bool IsTrailEnd { get; set; }
        public bool IsPaid { get; set; }
        public virtual ICollection<tblAdministratorSetting> tblAdministratorSettings { get; set; }
        public virtual ICollection<tblAuthorisationRuleSetting> tblAuthorisationRuleSettings { get; set; }
        public virtual ICollection<tblCompanySetting> tblCompanySettings { get; set; }
        public virtual ICollection<tblDomainDetail> tblDomainDetails { get; set; }
        public virtual ICollection<tblEmailSettings> tblEmailSettings { get; set; }
        public virtual ICollection<tblEmployeeDetail> tblEmployeeDetails { get; set; }
        public virtual ICollection<tblEmployeeSetting> tblEmployeeSettings { get; set; }
        public virtual ICollection<tblHolidays_AbsenceSettings> tblHolidays_AbsenceSettings { get; set; }
        public virtual ICollection<tblLocalizationSetting> tblLocalizationSettings { get; set; }
        public virtual ICollection<tblPerformanceReviewSetting> tblPerformanceReviewSettings { get; set; }
    }
}

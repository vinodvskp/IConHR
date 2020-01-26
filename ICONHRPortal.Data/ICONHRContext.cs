using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Data.Models.Mapping;

namespace ICONHRPortal.Data
{
    public partial class ICONHRContext : DbContext
    {
        static ICONHRContext()
        {
            Database.SetInitializer<ICONHRContext>(null);
        }

        public ICONHRContext()
            : base("Name=ICONHRContext")
        {
        }
        public DbSet<EmployeeTimesheet> EmployeeTimesheets { get; set; }
        public DbSet<EmpMgrPerReviewSegment> EmpMgrPerReviewSegments { get; set; }
        public DbSet<lkpCardExpMonth> CardExpMonths { get; set; }
        public DbSet<lkpCardExpYear> CardExpYears { get; set; }
        public DbSet<lkpCardType> CardTypes { get; set; }
        public DbSet<lkpCountry> Countries { get; set; }
        public DbSet<lkpDepartment> Departments { get; set; }
        public DbSet<lkpDocumentCategoryType> DocumentCategoryTypes { get; set; }
        public DbSet<lkpPlannerCategoryType> PlannerCategoryTypes { get; set; }
        public DbSet<lkpEmployeeRole> EmployeeRoles { get; set; }
        public DbSet<lkpEmploymentType> EmploymentTypes { get; set; }
        public DbSet<lkpJobType> JobTypes { get; set; }
        public DbSet<lkpLanguage> Languages { get; set; }
        public DbSet<lkpLocation> Locations { get; set; }
        public DbSet<PerformanceReviewSetting> PerformanceReviewSettings { get; set; }
        public DbSet<tblAdminDetail> AdminDetails { get; set; }
        public DbSet<tblAdministratorSetting> AdministratorSettings { get; set; }
        public DbSet<tblAuthorisationRuleSetting> AuthorisationRuleSettings { get; set; }
        public DbSet<tblCompanyDetail> CompanyDetails { get; set; }
        public DbSet<tblCompanySetting> CompanySettings { get; set; }
        public DbSet<tblCreditCardBillingDetail> CreditCardBillingDetails { get; set; }
        public DbSet<tblCreditCardDetail> CreditCardDetails { get; set; }
        public DbSet<tblDomainDetail> DomainDetails { get; set; }
        public DbSet<tblDocument> Documents { get; set; }
        public DbSet<tblEmailSettings> EmailSettings { get; set; }
        public DbSet<tblEmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<tblEmployeeJobDetail> EmployeeJobDetails { get; set; }
        public DbSet<tblEmployeePerformance> EmployeePerformance { get; set; }
        public DbSet<tblEmployeeSetting> EmployeeSettings { get; set; }
        public DbSet<tblHolidays_AbsenceSettings> HolidaysAbsenceSettings { get; set; }
        public DbSet<tblEmpPerReviewPerformance> tblEmpPerReviewPerformances { get; set; }
        public DbSet<tblEmpPerReviewRating> tblEmpPerReviewRatings { get; set; }
        public DbSet<tblEmpPerReviewSegment> tblEmpPerReviewSegments { get; set; }
        public DbSet<tblJobRole> JobRoles { get; set; }
        public DbSet<tblLocalizationSetting> LocalizationSettings { get; set; }
        public DbSet<tblLogBook> tblLogBooks { get; set; }
        public DbSet<tblManagerPerformance> ManagerPerformance { get; set; }
        public DbSet<tblMgrPerReviewPerformance> tblMgrPerReviewPerformances { get; set; }
        public DbSet<tblMgrPerReviewRating> tblMgrPerReviewRatings { get; set; }
        public DbSet<tblMgrPerReviewSegment> tblMgrPerReviewSegments { get; set; }
        public DbSet<tblPerformaceSegmentQuestion> PerformaceSegmentQuestions { get; set; }
        public DbSet<tblPlanner> Planners { get; set; }
        public DbSet<tblPerformanceScore> PerformanceScore { get; set; }
        public DbSet<tblPerformanceReviewSetting> ReviewSettings { get; set; }
        public DbSet<tblPerformanceSegment> PerformanceSegments { get; set; }
        public DbSet<tblReportingManager> ReportingManagers { get; set; }
        public DbSet<WorkPattern> WorkPatterns { get; set; }
        public DbSet<tblNotifications> tblNotification { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeTimesheetMap());
            modelBuilder.Configurations.Add(new EmpMgrPerReviewSegmentMap());
            modelBuilder.Configurations.Add(new lkpCardExpMonthMap());
            modelBuilder.Configurations.Add(new lkpCardExpYearMap());
            modelBuilder.Configurations.Add(new lkpCardTypeMap());
            modelBuilder.Configurations.Add(new lkpCountryMap());
            modelBuilder.Configurations.Add(new lkpDepartmentMap());
            modelBuilder.Configurations.Add(new lkpDocumentCategoryTypeMap());
            modelBuilder.Configurations.Add(new lkpEmployeeRoleMap());
            modelBuilder.Configurations.Add(new lkpEmploymentTypeMap());
            modelBuilder.Configurations.Add(new lkpJobTypeMap());
            modelBuilder.Configurations.Add(new lkpLanguageMap());
            modelBuilder.Configurations.Add(new lkpLocationMap());
            modelBuilder.Configurations.Add(new PerformanceReviewSettingMap());
            modelBuilder.Configurations.Add(new tblAdminDetailMap());
            modelBuilder.Configurations.Add(new tblAdministratorSettingMap());
            modelBuilder.Configurations.Add(new tblAuthorisationRuleSettingMap());
            modelBuilder.Configurations.Add(new tblCompanyDetailMap());
            modelBuilder.Configurations.Add(new tblCompanySettingMap());
            modelBuilder.Configurations.Add(new tblCreditCardBillingDetailMap());
            modelBuilder.Configurations.Add(new tblCreditCardDetailMap());
            modelBuilder.Configurations.Add(new tblDomainDetailMap());
            modelBuilder.Configurations.Add(new lkpPlannerCategoryTypeMap());
            modelBuilder.Configurations.Add(new tblDocumentMap());
            modelBuilder.Configurations.Add(new tblEmailSettingMap());
            modelBuilder.Configurations.Add(new tblEmployeeDetailMap());
            modelBuilder.Configurations.Add(new tblEmployeeJobDetailMap());
            modelBuilder.Configurations.Add(new tblEmployeeSettingMap());
            modelBuilder.Configurations.Add(new tblEmpPerReviewPerformanceMap());
            modelBuilder.Configurations.Add(new tblEmpPerReviewRatingMap());
            modelBuilder.Configurations.Add(new tblEmpPerReviewSegmentMap());
            modelBuilder.Configurations.Add(new tblEmployeePerformanceMap());
            modelBuilder.Configurations.Add(new tblHolidays_AbsenceSettingsMap());
            modelBuilder.Configurations.Add(new tblJobRoleMap());
            modelBuilder.Configurations.Add(new tblLocalizationSettingMap());
            modelBuilder.Configurations.Add(new tblLogBookMap());
            modelBuilder.Configurations.Add(new tblManagerPerformanceMap());
            modelBuilder.Configurations.Add(new tblPerformaceSegmentQuestionMap());
            modelBuilder.Configurations.Add(new tblPerformanceScoreMap());
            modelBuilder.Configurations.Add(new tblPerformanceReviewSettingMap());
            modelBuilder.Configurations.Add(new tblPerformanceSegmentMap());
            modelBuilder.Configurations.Add(new tblMgrReviewPerformanceMap());
            modelBuilder.Configurations.Add(new tblMgrPerReviewRatingMap());
            modelBuilder.Configurations.Add(new tblMgrPerReviewSegmentMap());
            modelBuilder.Configurations.Add(new tblPlannerMap());
            modelBuilder.Configurations.Add(new tblReportingManagerMap());
            modelBuilder.Configurations.Add(new WorkPatternMap());
            modelBuilder.Configurations.Add(new tblNotificationsMap());
        }
    }
}
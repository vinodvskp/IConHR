//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using ICONHRPortal.Data.Models.Mapping;

//namespace ICONHRPortal.Data.Models
//{
//    public partial class ICONHRContext : DbContext
//    {
//        static ICONHRContext()
//        {
//            Database.SetInitializer<ICONHRContext>(null);
//        }

//        public ICONHRContext()
//            : base("Name=ICONHRContext")
//        {
//        }

//        public DbSet<EmployeeTimesheet> EmployeeTimesheets { get; set; }
//        public DbSet<EmpMgrPerReviewSegment> EmpMgrPerReviewSegments { get; set; }
//        public DbSet<lkpCardExpMonth> lkpCardExpMonths { get; set; }
//        public DbSet<lkpCardExpYear> lkpCardExpYears { get; set; }
//        public DbSet<lkpCardType> lkpCardTypes { get; set; }
//        public DbSet<lkpCountry> lkpCountries { get; set; }
//        public DbSet<lkpDepartment> lkpDepartments { get; set; }
//        public DbSet<lkpDocumentCategoryType> lkpDocumentCategoryTypes { get; set; }
//        public DbSet<lkpEmployeeRole> lkpEmployeeRoles { get; set; }
//        public DbSet<lkpEmploymentType> lkpEmploymentTypes { get; set; }
//        public DbSet<lkpJobType> lkpJobTypes { get; set; }
//        public DbSet<lkpLanguage> lkpLanguages { get; set; }
//        public DbSet<lkpLocation> lkpLocations { get; set; }
//        public DbSet<lkpPlannerCategoryType> lkpPlannerCategoryTypes { get; set; }
//        public DbSet<PerformanceReviewSetting> PerformanceReviewSettings { get; set; }
//        public DbSet<tblAdminDetail> tblAdminDetails { get; set; }
//        public DbSet<tblAdministratorSetting> tblAdministratorSettings { get; set; }
//        public DbSet<tblAuthorisationRuleSetting> tblAuthorisationRuleSettings { get; set; }
//        public DbSet<tblCompanyDetail> tblCompanyDetails { get; set; }
//        public DbSet<tblCompanySetting> tblCompanySettings { get; set; }
//        public DbSet<tblCreditCardBillingDetail> tblCreditCardBillingDetails { get; set; }
//        public DbSet<tblCreditCardDetail> tblCreditCardDetails { get; set; }
//        public DbSet<tblDocument> tblDocuments { get; set; }
//        public DbSet<tblDomainDetail> tblDomainDetails { get; set; }
//        public DbSet<tblEmailSetting> tblEmailSettings { get; set; }
//        public DbSet<tblEmployeeDetail> tblEmployeeDetails { get; set; }
//        public DbSet<tblEmployeeJobDetail> tblEmployeeJobDetails { get; set; }
//        public DbSet<tblEmployeePerformance> tblEmployeePerformances { get; set; }
//        public DbSet<tblEmployeeSetting> tblEmployeeSettings { get; set; }
//        public DbSet<tblEmpPerReviewPerformance> tblEmpPerReviewPerformances { get; set; }
//        public DbSet<tblEmpPerReviewRating> tblEmpPerReviewRatings { get; set; }
//        public DbSet<tblEmpPerReviewSegment> tblEmpPerReviewSegments { get; set; }
//        public DbSet<tblHolidays_AbsenceSettings> tblHolidays_AbsenceSettings { get; set; }
//        public DbSet<tblJobRole> tblJobRoles { get; set; }
//        public DbSet<tblLocalizationSetting> tblLocalizationSettings { get; set; }
//        public DbSet<tblLogBook> tblLogBooks { get; set; }
//        public DbSet<tblManagerPerformance> tblManagerPerformances { get; set; }
//        public DbSet<tblMgrPerReviewPerformance> tblMgrPerReviewPerformances { get; set; }
//        public DbSet<tblMgrPerReviewRating> tblMgrPerReviewRatings { get; set; }
//        public DbSet<tblMgrPerReviewSegment> tblMgrPerReviewSegments { get; set; }
//        public DbSet<tblNotification> tblNotifications { get; set; }
//        public DbSet<tblPerformaceSegmentQuestion> tblPerformaceSegmentQuestions { get; set; }
//        public DbSet<tblPerformanceReviewSetting> tblPerformanceReviewSettings { get; set; }
//        public DbSet<tblPerformanceScore> tblPerformanceScores { get; set; }
//        public DbSet<tblPerformanceSegment> tblPerformanceSegments { get; set; }
//        public DbSet<tblPlanner> tblPlanners { get; set; }
//        public DbSet<tblReportingManager> tblReportingManagers { get; set; }
//        public DbSet<WorkPattern> WorkPatterns { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Configurations.Add(new EmployeeTimesheetMap());
//            modelBuilder.Configurations.Add(new EmpMgrPerReviewSegmentMap());
//            modelBuilder.Configurations.Add(new lkpCardExpMonthMap());
//            modelBuilder.Configurations.Add(new lkpCardExpYearMap());
//            modelBuilder.Configurations.Add(new lkpCardTypeMap());
//            modelBuilder.Configurations.Add(new lkpCountryMap());
//            modelBuilder.Configurations.Add(new lkpDepartmentMap());
//            modelBuilder.Configurations.Add(new lkpDocumentCategoryTypeMap());
//            modelBuilder.Configurations.Add(new lkpEmployeeRoleMap());
//            modelBuilder.Configurations.Add(new lkpEmploymentTypeMap());
//            modelBuilder.Configurations.Add(new lkpJobTypeMap());
//            modelBuilder.Configurations.Add(new lkpLanguageMap());
//            modelBuilder.Configurations.Add(new lkpLocationMap());
//            modelBuilder.Configurations.Add(new lkpPlannerCategoryTypeMap());
//            modelBuilder.Configurations.Add(new PerformanceReviewSettingMap());
//            modelBuilder.Configurations.Add(new tblAdminDetailMap());
//            modelBuilder.Configurations.Add(new tblAdministratorSettingMap());
//            modelBuilder.Configurations.Add(new tblAuthorisationRuleSettingMap());
//            modelBuilder.Configurations.Add(new tblCompanyDetailMap());
//            modelBuilder.Configurations.Add(new tblCompanySettingMap());
//            modelBuilder.Configurations.Add(new tblCreditCardBillingDetailMap());
//            modelBuilder.Configurations.Add(new tblCreditCardDetailMap());
//            modelBuilder.Configurations.Add(new tblDocumentMap());
//            modelBuilder.Configurations.Add(new tblDomainDetailMap());
//            modelBuilder.Configurations.Add(new tblEmailSettingMap());
//            modelBuilder.Configurations.Add(new tblEmployeeDetailMap());
//            modelBuilder.Configurations.Add(new tblEmployeeJobDetailMap());
//            modelBuilder.Configurations.Add(new tblEmployeePerformanceMap());
//            modelBuilder.Configurations.Add(new tblEmployeeSettingMap());
//            modelBuilder.Configurations.Add(new tblEmpPerReviewPerformanceMap());
//            modelBuilder.Configurations.Add(new tblEmpPerReviewRatingMap());
//            modelBuilder.Configurations.Add(new tblEmpPerReviewSegmentMap());
//            modelBuilder.Configurations.Add(new tblHolidays_AbsenceSettingsMap());
//            modelBuilder.Configurations.Add(new tblJobRoleMap());
//            modelBuilder.Configurations.Add(new tblLocalizationSettingMap());
//            modelBuilder.Configurations.Add(new tblLogBookMap());
//            modelBuilder.Configurations.Add(new tblManagerPerformanceMap());
//            modelBuilder.Configurations.Add(new tblMgrPerReviewPerformanceMap());
//            modelBuilder.Configurations.Add(new tblMgrPerReviewRatingMap());
//            modelBuilder.Configurations.Add(new tblMgrPerReviewSegmentMap());
//            modelBuilder.Configurations.Add(new tblNotificationMap());
//            modelBuilder.Configurations.Add(new tblPerformaceSegmentQuestionMap());
//            modelBuilder.Configurations.Add(new tblPerformanceReviewSettingMap());
//            modelBuilder.Configurations.Add(new tblPerformanceScoreMap());
//            modelBuilder.Configurations.Add(new tblPerformanceSegmentMap());
//            modelBuilder.Configurations.Add(new tblPlannerMap());
//            modelBuilder.Configurations.Add(new tblReportingManagerMap());
//            modelBuilder.Configurations.Add(new WorkPatternMap());
//        }
//    }
//}

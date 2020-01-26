using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.BusninessLogic.Service;
using ICONHRPortal.Data;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Repository;
using System;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace ICONHRPortal
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            container.RegisterType<IEmployeeDetailsService, EmployeeDetailsService>();
            container.RegisterType<IEmployeeDetailsRepository, EmployeeDetailsRepository>();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<ICountryRepository, CountryRepository>();
            container.RegisterType<ICardTypeRepository, CardTypeRepository>();
            container.RegisterType<ICardExpireMonthRepository, CardExpireMonthRepository>();
            container.RegisterType<ICardExpireYearRepository, CardExpireYearRepository>();
            container.RegisterType<IPaymentService, PaymentService>();
            container.RegisterType<IPaymentRepository, PaymentRepository>();
            container.RegisterType<IHolidaysAbsenceSettingRepository, HolidaysAbsenceSettingRepository>();
            container.RegisterType<IHolidaysAbsenceSettingService, HolidaysAbsenceSettingService>();
            container.RegisterType<IEmployeeSettingRepository, EmployeeSettingRepository>();
            container.RegisterType<IEmployeeSettingService, EmployeeSettingService>();
            container.RegisterType<IEmailSettingRepository, EmailSettingRepository>();
            container.RegisterType<IEmailSettingService, EmailSettingService>();
            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<ILocationService, LocationService>();
            container.RegisterType<ICompanyDetailsRepository, CompanyDetailsRepository>();
            container.RegisterType<ICompanyDetailService, CompanyDetailService>();
            container.RegisterType<ICompanySettingRepository, CompanySettingRepository>();
            container.RegisterType<ICompanySettingService, CompanySettingService>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IWorkPatternRepository, WorkPatternRepository>();
            container.RegisterType<IWorkPatternService, WorkPatternService>();
            container.RegisterType<IAdministratorSettingRepository, AdministratorSettingRepository>();
            container.RegisterType<IAdministratorSettingService, AdministratorSettingService>();
            container.RegisterType<IEmployeeTimesheetRepository, EmployeeTimesheetRepository>();
            container.RegisterType<IEmployeeTimesheetService, EmployeeTimesheetService>();
            container.RegisterType<IDocumentRepository, DocumentRepository>();
            container.RegisterType<IDocumentService, DocumentService>();
            container.RegisterType<IPlannerRepository, PlannerRepository>();
            container.RegisterType<IPlannerService, PlannerService>();
            container.RegisterType<IDocumentCategoryTypeRepository, DocumentCategoryTypeRepository>();
            container.RegisterType<IPlannerCategoryTypeRepository, PlannerCategoryTypeRepository>();
            container.RegisterType<IEmployeeLogBookRepository, EmployeeLogBookRepository>();
            container.RegisterType<IEmployeeLogBookService, EmployeeLogBookService>();
            container.RegisterType<IPerformanceReviewSettingRepository, PerformanceReviewSettingRepository>();
            container.RegisterType<IPerformanceReviewSettingService, PerformanceReviewSettingService>();
            container.RegisterType<IPerformanceScoreRepository, PerformanceScoreRepository>();
            container.RegisterType<IPerformanceSegmentRepository, PerformanceSegmentRepository>();
            container.RegisterType<IPerformanceSegmentService, PerformanceSegmentService>();
            container.RegisterType<IJobRoleRepository, JobRoleRepository>();
            container.RegisterType<IEmploymentTypeRepository, EmploymentTypeRepository>();
            container.RegisterType<IEmployeePerformanceRepository, EmployeePerformanceRepository>();
            container.RegisterType<IEmployeePerformanceService, EmployeePerformanceService>();
            container.RegisterType<IManagerPerformanceRepository, ManagerPerformanceRepository>();
            container.RegisterType<IAuthorisationRuleSettingRepository, AuthorisationRuleSettingRepository>();
            container.RegisterType<IAuthorisationRuleSettingService, AuthorisationRuleSettingService>();
            container.RegisterType<IEmployeeNotificationRepository, EmployeeNotificationRepository>();
            container.RegisterType<IPerformancesegmentQuestionRepository, PerformancesegmentQuestionRepository>();
            container.RegisterType<IEmpPerReviewRepository, EmpPerReviewRepository>();
            container.RegisterType<IEmpReviewSegmentRepository, EmpReviewSegmentRepository>();
            container.RegisterType<IEmpReviewRatingRepository, EmpReviewRatingRepository>();
            container.RegisterType<IEmpReviewService, EmpReviewService>();
            container.RegisterType<IMgrPerReviewRepository, MgrPerReviewRepository>();
            container.RegisterType<IMgrReviewSegmentRepository, MgrReviewSegmentRepository>();
            container.RegisterType<IMgrReviewRatingRepository, MgrReviewRatingRepository>();
            container.RegisterType<IManagerPerformanceService, ManagerPerformanceService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
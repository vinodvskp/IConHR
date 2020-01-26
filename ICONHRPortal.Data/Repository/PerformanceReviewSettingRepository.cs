using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;
using System.Data.Entity;

namespace ICONHRPortal.Data.Repository
{
    public class PerformanceReviewSettingRepository : GenericRepository<tblPerformanceReviewSetting>,
        IPerformanceReviewSettingRepository
    {
        public PerformanceReviewSettingRepository(ICONHRContext context) : base(context)
        {

        }

        public IEnumerable<PerformanceReviewSettingModel> GetPerformanceSettings()
        {

            return from prs in _IconhrContext.ReviewSettings
                   join loc in _IconhrContext.Locations
                       on prs.LocationID equals loc.LocationId
                   join dept in _IconhrContext.Departments on prs.DepartmentID equals dept.DeptID
                   join jobRole in _IconhrContext.JobRoles on prs.JobRoleID equals jobRole.JobRoleID
                   join empType in _IconhrContext.EmploymentTypes on prs.EmploymentTypeID equals empType.EmploymentTypeID
                   select new PerformanceReviewSettingModel()
                   {
                       CompanyID = prs.CompanyID,
                       DepartmentID = prs.DepartmentID,
                       DepartmentName = dept.DeptName,
                       CreatedBy = prs.CreatedBy,
                       CreatedDate = prs.CreatedDate,
                       EmploymentTypeID = empType.EmploymentTypeID,
                       EmploymentTypeName = empType.EmploymentTypeDesc,
                       JobRoleID = jobRole.JobRoleID,
                       JobRoleName = jobRole.JobRole,
                       LengthOfService = prs.LengthOfService,
                       LocationID = prs.LocationID,
                       LocationName = loc.Location,
                       PerformanceReviewID = prs.PerformanceReviewID,
                       LastUpdatedBy = prs.LastUpdatedBy,
                       LastUpdatedDate = prs.LastUpdatedDate,
                       Status = prs.Status,
                       ReviewCompletionDate = prs.ReviewCompletionDate,
                       ReviewTitle = prs.ReviewTitle
                   };
        }

        public tblPerformanceReviewSetting GetPerformanceSettingsById(int id)
        {
            return _IconhrContext.ReviewSettings.Include("tblPerformanceSegments")
                .Include(x => x.tblPerformanceSegments.Select(y => y.tblPerformaceSegmentQuestions))
                .Include("tblPerformanceScores")
                .Where(x => x.PerformanceReviewID == id).FirstOrDefault();
        }
    }
}

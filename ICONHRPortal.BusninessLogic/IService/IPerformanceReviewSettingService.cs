using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IPerformanceReviewSettingService
    {
        List<PerformanceReviewSettingModel> GetPerformanceReviewSettings();
        PerformanceReviewSettingModel GetPerformanceReviewSetting(int id);
        int SavePerformanceReviewSetting(PerformanceReviewSettingModel model);
        int UpdatePerformanceReviewSetting(PerformanceReviewSettingModel model);
        int DeletePerformanceReviewSetting(int id);
        IEnumerable<ChoiceOptionModel> GetJobRoleNames();
        IEnumerable<ChoiceOptionModel> GetEmploymentTypes();
        IEnumerable<ChoiceOptionModel> GetReviewNames();
    }
}
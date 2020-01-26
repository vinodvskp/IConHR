using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IEmpReviewService
    {
        IEnumerable<EmpPerReviewPerformanceModel> EmpMgrPerReviewPerformanceById(int id);
        int Save(EmpPerReviewPerformanceModel model);
        int Update(EmpPerReviewPerformanceModel model);

        PerformanceReviewSettingModel GetEmpMgrPerformanceDetailsByReviewId(int empid, int rptMgrId,
            int EmpMgrReviewId);
        SP_EmpScoreDetailsModel GetEmployeeScoreDetails(int empReviewId, int empid, int rptMgrId);
    }
}

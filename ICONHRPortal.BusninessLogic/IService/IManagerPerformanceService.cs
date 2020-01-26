using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IManagerPerformanceService
    {
        IEnumerable<MgrPerReviewPerformanceModel> MgrPerReviewPerformanceById(int id);
        int Save(MgrPerReviewPerformanceModel model);
        int Update(MgrPerReviewPerformanceModel model);

        PerformanceReviewSettingModel GetMgrPerformanceDetailsByReviewId(int empid, int rptMgrId,
            int EmpMgrReviewId);
    }
}

using ICONHRPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Model;

namespace ICONHRPortal.Data.IRepository
{
    public interface IMgrPerReviewRepository : IGenericRepository<tblMgrPerReviewPerformance>
    {
        IEnumerable<MgrPerReviewPerformanceModel> GetMgrPerReviewPerformances();
        IEnumerable<MgrPerReviewPerformanceModel> GetMgrPerReviewPerformanceById(int id);

        IEnumerable<SP_EmpMgrPerformanceDetailsModel> GetSpMgrPerformanceDetails(int empid, int? rptMgrId,
            int empMgrReviewId);

        tblMgrPerReviewPerformance GetEmpPerReviewPerformancesById(int id);
    }
}

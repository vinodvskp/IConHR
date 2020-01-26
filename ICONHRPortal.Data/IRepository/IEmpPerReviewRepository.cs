using ICONHRPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Model;

namespace ICONHRPortal.Data.IRepository
{
    public interface IEmpPerReviewRepository : IGenericRepository<tblEmpPerReviewPerformance>
    {
        IEnumerable<EmpPerReviewPerformanceModel> GetEmpMgrPerReviewPerformances();
        IEnumerable<EmpPerReviewPerformanceModel> GetEmpMgrPerReviewPerformanceById(int id);

        IEnumerable<SP_EmpMgrPerformanceDetailsModel> GetSpEmpMgrPerformanceDetails(int empid, int? rptMgrId,
            int empMgrReviewId);

        tblEmpPerReviewPerformance GetEmpPerReviewPerformancesById(int id);
         SP_EmpScoreDetailsModel GetEmployeeScoreDetails(int empReviewId, int empid, int rptMgrId);
    }
}

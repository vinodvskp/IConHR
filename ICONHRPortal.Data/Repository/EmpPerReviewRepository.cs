using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;
using System.Data.Entity;

namespace ICONHRPortal.Data.Repository
{
    public class EmpPerReviewRepository : GenericRepository<tblEmpPerReviewPerformance>, IEmpPerReviewRepository
    {
        public EmpPerReviewRepository(ICONHRContext context) : base(context)
        {

        }

        public IEnumerable<EmpPerReviewPerformanceModel> GetEmpMgrPerReviewPerformanceById(int id)
        {
            var data = (from empMgrReview in _IconhrContext.tblEmpPerReviewPerformances
                        join emp in _IconhrContext.EmployeeDetails
                            on empMgrReview.EmpID equals emp.EmpID
                        join reviewsettings in _IconhrContext.ReviewSettings on empMgrReview.PerformanceReviewID equals
                            reviewsettings.PerformanceReviewID
                        where empMgrReview.EmpID == id
                        select new EmpPerReviewPerformanceModel
                        {
                            EmpReviewID = empMgrReview.EmpReviewID,
                            EmpID = empMgrReview.EmpID,
                            EmployeeName = emp.EmpName,
                            PerformanceReviewID = empMgrReview.PerformanceReviewID,
                            ReviewTitle = reviewsettings.ReviewTitle,
                            RepMgrID = empMgrReview.RepMgrID,
                            ManagerName = emp.EmpName, // TODO name should be reporting manager may b from empjobdetails
                                                       //TotalScore = totalCount
                        }).OrderByDescending(x => x.EmpReviewID).ToList();
            foreach (var item in data)
            {
                item.TotalScore = _IconhrContext.Database.SqlQuery<decimal?>("select sum(c.ScoreID)/CONVERT(decimal(4,2),count(c.ScoreID)) from tblEmpPerReviewSegment as a " +
                                                                           "join tblEmpPerReviewSegment as b  on a.EmpReviewID = b.EmpReviewID join  tblEmpPerReviewRating as c " +
                                                                           "on b.EmpReviewSegmentID = c.EmpReviewSegmentID where a.EmpReviewID =" + item.EmpReviewID).FirstOrDefault();
            }

            return data;
        }

        public IEnumerable<SP_EmpMgrPerformanceDetailsModel> GetSpEmpMgrPerformanceDetails(int empid, int? rptMgrId, int empReviewId)
        {
            IEnumerable<SP_EmpMgrPerformanceDetailsModel> data = null;
            if (rptMgrId == null || rptMgrId == 0)
            {
                data = _IconhrContext.Database.SqlQuery<SP_EmpMgrPerformanceDetailsModel>(
                    "exec Get_PerformaceDetails @pAsEmpId=" + empid + " , @pAsPerformaceReviewId=" + empReviewId +
                    "").ToList();
                //new System.Data.SqlClient.SqlParameter("pAsEmpId", empid),
                //new System.Data.SqlClient.SqlParameter("pAsPerformaceReviewId", empMgrReviewId)).ToList();

            }
            else
            {
                //data = _IconhrContext.Database.SqlQuery<SP_EmpMgrPerformanceDetailsModel>(
                //    "exec Get_PerformaceDetails @pAsEmpId, @pAsRepMgrId, @pAsPerformaceReviewId",
                //    new System.Data.SqlClient.SqlParameter("@pAsEmpId", empid),
                //    new System.Data.SqlClient.SqlParameter("@pAsRepMgrId", rptMgrId),
                //    new System.Data.SqlClient.SqlParameter("@pAsPerformaceReviewId", empMgrReviewId)).ToList();
                data = _IconhrContext.Database.SqlQuery<SP_EmpMgrPerformanceDetailsModel>(
                    "exec Get_PerformaceDetails @pAsEmpId=" + empid + " , @pAsRepMgrId= " + rptMgrId + "@pAsPerformaceReviewId=" + empReviewId +
                    "");
            }
            return data;
        }

        public IEnumerable<EmpPerReviewPerformanceModel> GetEmpMgrPerReviewPerformances()
        {
            throw new NotImplementedException();
        }

        public tblEmpPerReviewPerformance GetEmpPerReviewPerformancesById(int id)
        {
            return _IconhrContext.tblEmpPerReviewPerformances.Include("tblEmpPerReviewSegments")
                //.Include("tblEmpPerReviewRatings")
                .Where(x => x.EmpReviewID == id).FirstOrDefault();
        }
        public SP_EmpScoreDetailsModel GetEmployeeScoreDetails(int empReviewId,int empid, int rptMgrId)
        {
            SP_EmpScoreDetailsModel data = null;
                data = _IconhrContext.Database.SqlQuery<SP_EmpScoreDetailsModel>(
                    "exec Get_emp_Mgr_Score @pASPerformanceReviewID=" + empReviewId + " , @pAsEmpID=" + empid + " , @pAsMgrID=" + rptMgrId).FirstOrDefault();
            return data;
        }
    }
}

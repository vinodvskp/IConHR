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
    public class MgrPerReviewRepository : GenericRepository<tblMgrPerReviewPerformance>, IMgrPerReviewRepository
    {
        public MgrPerReviewRepository(ICONHRContext context) : base(context)
        {

        }

        public IEnumerable<MgrPerReviewPerformanceModel> GetMgrPerReviewPerformanceById(int id)
        {
            var data = (from MgrReview in _IconhrContext.tblMgrPerReviewPerformances
                        join emp in _IconhrContext.EmployeeDetails
                            on MgrReview.EmpID equals emp.EmpID
                        join jobDetail in _IconhrContext.EmployeeJobDetails on emp.EmpID equals jobDetail.EmpID
                        join reviewsettings in _IconhrContext.ReviewSettings on MgrReview.PerformanceReviewID equals
                            reviewsettings.PerformanceReviewID
                        where MgrReview.EmpID == id
                        select new MgrPerReviewPerformanceModel
                        {
                            MgrReviewID = MgrReview.MgrReviewID,
                            EmpID = MgrReview.EmpID,
                            RepMgrID = jobDetail.RepMgrID,
                            PerformanceReviewID = MgrReview.PerformanceReviewID,
                            ReviewTitle = reviewsettings.ReviewTitle,
                            ManagerName = emp.EmpName, // TODO name should be reporting manager may b from empjobdetails
                                                       //TotalScore = totalCount
                        }).OrderByDescending(x => x.MgrReviewID).ToList();
            foreach (var item in data)
            {
                item.TotalScore = _IconhrContext.Database.SqlQuery<decimal?>("select sum(c.ScoreID)/CONVERT(decimal(4,2),count(c.ScoreID)) from tblMgrPerReviewSegment as a " +
                                                                           "join tblMgrPerReviewSegment as b  on a.MgrReviewID = b.MgrReviewID join  tblMgrPerReviewRating as c " +
                                                                           "on b.MgrReviewSegmentID = c.MgrReviewSegmentID where a.MgrReviewID =" + item.MgrReviewID).FirstOrDefault();
            }

            return data;
        }

        public IEnumerable<SP_EmpMgrPerformanceDetailsModel> GetSpMgrPerformanceDetails(int empid, int? rptMgrId, int empReviewId)
        {
            IEnumerable<SP_EmpMgrPerformanceDetailsModel> data = null;
            //if (rptMgrId == null || rptMgrId == 0)
            {
                data = _IconhrContext.Database.SqlQuery<SP_EmpMgrPerformanceDetailsModel>(
                    "exec Get_MgrPerformaceDetails @pAsEmpId=" + rptMgrId + " , @pAsPerformaceReviewId=" + empReviewId +
                    "").ToList();
            }
            //else
            //{
            //    data = _IconhrContext.Database.SqlQuery<SP_EmpMgrPerformanceDetailsModel>(
            //        "exec Get_MgrPerformaceDetails @pAsEmpId=" + empid + " , @pAsRepMgrId= " + rptMgrId + " @pAsPerformaceReviewId=" + empReviewId +
            //        "");
            //}
            return data;
        }

        public IEnumerable<MgrPerReviewPerformanceModel> GetMgrPerReviewPerformances()
        {
            throw new NotImplementedException();
        }

        public tblMgrPerReviewPerformance GetEmpPerReviewPerformancesById(int id)
        {
            return _IconhrContext.tblMgrPerReviewPerformances.Include("tblMgrPerReviewSegments")
                //.Include("tblMgrPerReviewRatings")
                .Where(x => x.MgrReviewID == id).FirstOrDefault();
        }
    }
}

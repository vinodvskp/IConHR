using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Model;

namespace ICONHRPortal.ApiService
{
    public class EmployeePerformanceApiController : BaseApiController
    {
        private readonly IEmpReviewService _empMgrReviewService = null;

        public EmployeePerformanceApiController(IEmpReviewService empMgrReviewService)
        {
            _empMgrReviewService = empMgrReviewService;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IEnumerable<EmpPerReviewPerformanceModel> Get(int id)
        {
            if (id == 0)
            {
                id = int.Parse(base.UserIdentity);
            }
            return _empMgrReviewService.EmpMgrPerReviewPerformanceById(id);
        }

        // POST api/<controller>
        public int Post([FromBody]EmpPerReviewPerformanceModel model)
        {
            if (model != null)
            {
                if (model.EmpReviewID == 0)
                {
                    model.CreatedBy = base.UserName;
                    model.CreatedDate = DateTime.Now;
                    model.Status = true;
                    model.EmpID = int.Parse(base.UserIdentity);
                    model.RepMgrID =
                        int.Parse(base.UserIdentity) != model.EmpID
                            ? model.EmpID
                            : null; // empid may be login or selected empid
                    //model.RepMgrID = base.ReportingManagerId;
                    foreach (var segments in model.tblEmpPerReviewSegments)
                    {
                        foreach (var question in segments.tblEmpPerReviewRatings)
                        {
                            question.CreatedDate = DateTime.Now;
                            question.CreatedBy = base.UserName;
                        }
                    }

                    return _empMgrReviewService.Save(model);
                }
                else
                {
                    model.UpdatedBy = base.UserName;
                    model.UpdatedDate = DateTime.Now;
                    model.Status = true;
                    model.EmpID = int.Parse(base.UserIdentity);
                    model.RepMgrID = int.Parse(base.UserIdentity) != model.EmpID ? model.EmpID : null;// empid may be login or selected empid
                    //model.RepMgrID = base.ReportingManagerId;
                    foreach (var segments in model.tblEmpPerReviewSegments)
                    {
                        foreach (var question in segments.tblEmpPerReviewRatings)
                        {
                            question.UpdatedDate = DateTime.Now;
                            question.UpdatedBy = base.UserName;
                        }
                    }
                    return _empMgrReviewService.Update(model);
                }
            }

            return 0;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/EmployeePerformanceApi/Sp_EmpMgrPerformanceDetails")]
        [ActionName("Sp_EmpMgrPerformanceDetails")] //
        public PerformanceReviewSettingModel Sp_EmpMgrPerformanceDetails(int empid, int rptMgrId, int empMgrReviewId)
        {
            //int id = int.Parse(base.UserIdentity);
            return _empMgrReviewService.GetEmpMgrPerformanceDetailsByReviewId(empid, rptMgrId, empMgrReviewId);
        }
        [HttpGet]
        [Route("api/EmployeePerformanceApi/GetEmployeeScoreDetails")]
        [ActionName("GetEmployeeScoreDetails")] //
        public SP_EmpScoreDetailsModel GetEmployeeScoreDetails(int id)
        {
            //int id = int.Parse(base.UserIdentity);
            return _empMgrReviewService.GetEmployeeScoreDetails(id,int.Parse(UserIdentity), ReportingManagerId);
        }
    }
}
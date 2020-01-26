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
    public class ManagerPerformanceApiController : BaseApiController
    {
        private readonly IManagerPerformanceService _managerPerformanceService = null;
        public ManagerPerformanceApiController(IManagerPerformanceService managerPerformanceService)
        {
            _managerPerformanceService = managerPerformanceService;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IEnumerable<MgrPerReviewPerformanceModel> Get(int id)
        {
            if (id == 0)
            {
                id = int.Parse(base.UserIdentity);
            }
            return _managerPerformanceService.MgrPerReviewPerformanceById(id);
        }

        // POST api/<controller>
        public int Post([FromBody]MgrPerReviewPerformanceModel model)
        {
            if (model != null && model.MgrReviewID == 0)
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
                foreach (var segments in model.tblMgrPerReviewSegments)
                {
                    foreach (var question in segments.tblMgrPerReviewRatings)
                    {
                        question.CreatedDate = DateTime.Now;
                        question.CreatedBy = base.UserName;
                    }
                }

               return _managerPerformanceService.Save(model);
            }
            else
            {
                model.UpdatedBy = base.UserName;
                model.UpdatedDate = DateTime.Now;
                model.Status = true;
                model.EmpID = int.Parse(base.UserIdentity);
                model.RepMgrID =
                    int.Parse(base.UserIdentity) != model.EmpID
                        ? model.EmpID
                        : null;
                foreach (var segments in model.tblMgrPerReviewSegments)
                {
                    foreach (var question in segments.tblMgrPerReviewRatings)
                    {
                        question.UpdatedDate = DateTime.Now;
                        question.UpdatedBy = base.UserName;
                    }
                }

               return _managerPerformanceService.Update(model);
            }
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
        [Route("api/ManagerPerformanceApi/Sp_MgrPerformanceDetails")]
        [ActionName("Sp_MgrPerformanceDetails")] //
        public PerformanceReviewSettingModel Sp_EmpMgrPerformanceDetails(int empid, int rptMgrId, int empMgrReviewId)
        {
            //int id = int.Parse(base.UserIdentity);
            return _managerPerformanceService.GetMgrPerformanceDetailsByReviewId(empid, rptMgrId, empMgrReviewId);
        }
    }
}
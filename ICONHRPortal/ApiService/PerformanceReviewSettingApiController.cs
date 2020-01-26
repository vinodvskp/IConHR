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
    public class PerformanceReviewSettingApiController : BaseApiController
    {
        private readonly IPerformanceReviewSettingService _performanceReviewSettingService = null;

        public PerformanceReviewSettingApiController(IPerformanceReviewSettingService performanceReviewSettingService)
        {
            _performanceReviewSettingService = performanceReviewSettingService;
        }

        // GET api/<controller>
        public IEnumerable<PerformanceReviewSettingModel> Get()
        {
            return _performanceReviewSettingService.GetPerformanceReviewSettings();
        }

        // GET api/<controller>/5
        public PerformanceReviewSettingModel Get(int id)
        {
            return _performanceReviewSettingService.GetPerformanceReviewSetting(id);
        }

        // POST api/<controller>
        public int Post([FromBody]PerformanceReviewSettingModel model)
        {
            if (model != null)
            {
                if (model.PerformanceReviewID == 0)
                {
                    model.CreatedBy = base.UserName;
                    model.CreatedDate = DateTime.Now;
                    model.CompanyID = base.CompanyId;
                    model.Status = true;
                    foreach (var item in model.tblPerformanceScores)
                    {
                        item.Status = true;
                    }

                    foreach (var item in model.tblPerformanceSegments)
                    {
                        foreach (var subItem in item.tblPerformaceSegmentQuestions)
                        {
                            subItem.CreatedDate = DateTime.Now;
                            subItem.CreatedBy = base.UserName;
                        }
                    }

                    return _performanceReviewSettingService.SavePerformanceReviewSetting(model);
                }
                else
                {
                    model.LastUpdatedBy = base.UserName;
                    model.LastUpdatedDate = DateTime.Now;
                    model.CompanyID = base.CompanyId;
                    model.Status = true;
                    foreach (var item in model.tblPerformanceSegments)
                    {
                        //item.UpdatedDate = DateTime.Now;
                        //item.UpdatedBy = base.UserName;
                        foreach (var subItem in item.tblPerformaceSegmentQuestions)
                        {
                            subItem.UpdatedDate = DateTime.Now;
                            subItem.UpdatedBy = base.UserName;
                        }
                    }

                    return _performanceReviewSettingService.UpdatePerformanceReviewSetting(model);
                }
            }

            return 0;
        }

        // PUT api/<controller>/5
        public int Put([FromBody]PerformanceReviewSettingModel model)
        {
            return _performanceReviewSettingService.UpdatePerformanceReviewSetting(model);
        }

        // DELETE api/<controller>/5
        public int Delete(int id)
        {
            return _performanceReviewSettingService.DeletePerformanceReviewSetting(id);
        }

        [HttpGet]
        [Route("api/PerformanceReviewSettingApi/JobRoles")]
        [ActionName("JobRoles")] //
        public IEnumerable<ChoiceOptionModel> JobRoles()
        {
            return _performanceReviewSettingService.GetJobRoleNames();
        }

        [HttpGet]
        [Route("api/PerformanceReviewSettingApi/EmployementTypes")]
        [ActionName("EmployementTypes")] //
        public IEnumerable<ChoiceOptionModel> EmployementTypes()
        {
            return _performanceReviewSettingService.GetEmploymentTypes();
        }

        [HttpGet]
        [Route("api/PerformanceReviewSettingApi/ReviewNames")]
        [ActionName("ReviewNames")] //
        public IEnumerable<ChoiceOptionModel> ReviewNames()
        {
            return _performanceReviewSettingService.GetReviewNames();
        }
    }
}
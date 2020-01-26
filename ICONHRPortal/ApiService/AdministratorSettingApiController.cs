using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Model;
using Microsoft.AspNet.Identity;

namespace ICONHRPortal.ApiService
{
    public class AdministratorSettingApiController : BaseApiController
    {
        private readonly IAdministratorSettingService _administratorSettingService = null;

        public AdministratorSettingApiController(IAdministratorSettingService administratorSettingService)
        {
            _administratorSettingService = administratorSettingService;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IEnumerable<AdministratorSettingModel> Get(int id)
        {
            return _administratorSettingService.GetAdminSettingDetailsByCompanyId(base.CompanyId);
        }

        // POST api/<controller>
        public void Post([FromBody]AdministratorSettingModel model)
        {
            model.CompanyID = CompanyId;
            model.LastUpdatedBy = HttpContext.Current.User.Identity.GetUserName();
            _administratorSettingService.SaveAdminSetting(model);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]AdministratorSettingModel model)
        {
            model.CompanyID = CompanyId;
            _administratorSettingService.UpdateAdminSetting(model);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/AdministratorSettingApi/AdminMangerNames")]
        [ActionName("AdminMangerNames")] //
        public IEnumerable<ChoiceOptionModel> AdminMangerNames()
        {
            return _administratorSettingService.GetAdminManagerNames();
        }
    }
}
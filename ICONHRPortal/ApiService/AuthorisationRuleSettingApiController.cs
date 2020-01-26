using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Extensions;
using ICONHRPortal.Model;


namespace ICONHRPortal.ApiService
{
   
    
    public class AuthorisationRuleSettingApiController : BaseApiController
    {
        private readonly IAuthorisationRuleSettingService _authorisationRuleSettingService = null;

        public AuthorisationRuleSettingApiController(IAuthorisationRuleSettingService authorisationRuleSettingService)
        {
            _authorisationRuleSettingService = authorisationRuleSettingService;
        }
        public IEnumerable<tblAuthorisationRuleSettingModel> GetAuthorisationRuleDetails()
        {
            return _authorisationRuleSettingService.GetAuthorisationRuleDetails();
        }
        public void Post([FromBody]tblAuthorisationRuleSettingModel model)
        {


            if (model.AuthorisationRuleSettingsID == 0)
            {
              //  model.CreatedBy = UserName;
                model.CreatedDate = DateTime.Now;
           //     model.LastUpdatedBy = UserName;
                model.UpdateDate = DateTime.Now;
                _authorisationRuleSettingService.Save(model);
            }
            else
            {
                model.UpdateDate = DateTime.Now;
                _authorisationRuleSettingService.Update(model);
            }
        }
    }
}
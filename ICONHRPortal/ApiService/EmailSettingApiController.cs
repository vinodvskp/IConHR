using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Model;


namespace ICONHRPortal.ApiService
{
    public class EmailSettingApiController : BaseApiController
    {
        
        // GET: EmployeeSetting
        private readonly IEmailSettingService _emailSettingService = null;
        public EmailSettingApiController(IEmailSettingService emailSettingService)
        {
           
            _emailSettingService = emailSettingService;
        }
        // GET api/<controller>
        public IEnumerable<tblEmailSettingModel> Get()
        {
            return _emailSettingService.GetEmailSettings();
        }

        // GET api/<controller>/5
        public tblEmailSettingModel Get(int id)
        {
            id= base.CompanyId;
            return _emailSettingService.GetEmailSetting(id);
        }

        // POST api/<controller>
        public void Post([FromBody]tblEmailSettingModel model)
        {
             model.CompanyID = base.CompanyId;
            _emailSettingService.Save(model);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]tblEmailSettingModel model)
        {
            _emailSettingService.Update(model);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
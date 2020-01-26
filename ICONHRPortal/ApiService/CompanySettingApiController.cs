using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.BusninessLogic.Service;
using ICONHRPortal.Model;

namespace ICONHRPortal.ApiService
{
    public class CompanySettingApiController : BaseApiController
    {
        private readonly ICompanySettingService _companySettingService = null;
        public CompanySettingApiController(ICompanySettingService companySettingService)
        {
            _companySettingService = companySettingService;
        }
        // GET api/<controller>
        public IEnumerable<CompanySettingModel> Get()
        {
            return _companySettingService.GetCompanySettings();
        }

        // GET api/<controller>/5
        public CompanySettingModel Get(int id)
        {
            id = base.CompanyId;
            return _companySettingService.GetCompanySettingById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]CompanySettingModel model)
        {
            model.CreatedDate = DateTime.Now;
            model.CompanyID = base.CompanyId;
            if (model.UploadLogoBase64 != null)
            {
                model.UploadLogo = System.Convert.FromBase64String(model.UploadLogoBase64);
            }
            _companySettingService.SaveCompanySetting(model);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
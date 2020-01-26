using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Model;
using ICONHRPortal.Models;

namespace ICONHRPortal.ApiService
{
    public class CompanyDetailController : BaseApiController
    {

        private readonly ICompanyDetailService _companyDetailsService = null;
        public CompanyDetailController(ICompanyDetailService companyDetailsService)
        {
            _companyDetailsService = companyDetailsService;
        }
        // GET api/<controller>
        public IEnumerable<CompanyDetailModel> Get()
        {
            int mgrId = base.ReportingManagerId;
            return _companyDetailsService.GetCompanyDetails();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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
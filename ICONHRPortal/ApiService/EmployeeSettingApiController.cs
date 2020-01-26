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
    public class EmployeeSettingApiController : BaseApiController
    {
        // GET: EmployeeSetting
        private readonly IEmployeeSettingService _employeeSettingService = null;
        public EmployeeSettingApiController(IEmployeeSettingService employeeSettingService)
        {
            _employeeSettingService = employeeSettingService;
        }
        // GET api/<controller>
        public IEnumerable<tblEmployeeSettingModel> Get()
        {
            return _employeeSettingService.GetEmployeeSettings();
        }

        // GET api/<controller>/5
        public tblEmployeeSettingModel Get(int id)
        {
            id = base.CompanyId;
            return _employeeSettingService.GetEmployeeSetting(id);
        }

        // POST api/<controller>
        public void Post([FromBody]tblEmployeeSettingModel model)
        {
            model.CompanyID = base.CompanyId;
            _employeeSettingService.Save(model);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]tblEmployeeSettingModel model)
        {
            _employeeSettingService.Update(model);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
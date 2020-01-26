using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Model;

namespace ICONHRPortal.ApiService
{
    public class EmployeeTimesheetApiController : BaseApiController
    {
        private readonly IEmployeeTimesheetService _employeeTimesheetService = null;

        public EmployeeTimesheetApiController(IEmployeeTimesheetService employeeTimesheetService)
        {
            _employeeTimesheetService = employeeTimesheetService;
        }

        // GET api/<controller>
        public IEnumerable<EmployeeTimesheetModel> GetTimeSheetsByRptMng()
        {
            long id = Convert.ToInt32(UserIdentity);
            return _employeeTimesheetService.GetTimeSheetsByRptMng(id);
        }
        // GET api/<controller>
        public IEnumerable<EmployeeTimesheetModel> Get()
        {
            long id= Convert.ToInt32(UserIdentity);
            return _employeeTimesheetService.GetEmployeeTimesheets(id);
        }

        // GET api/<controller>/5
        public EmployeeTimesheetModel Get(int id)
        {
            return _employeeTimesheetService.GetEmployeeTimesheet(id);
        }

        // POST api/<controller>
        public void Post([FromBody]EmployeeTimesheetModel model)
        {
            model.IsSubmited = true;
            model.EmpID = Convert.ToInt32(UserIdentity);
            model.EmpName = UserName;
            model.Approver = ReportingManagerId;
            if (model.TimesheetID == 0)
                _employeeTimesheetService.Save(model);
            else
                _employeeTimesheetService.Update(model);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]EmployeeTimesheetModel model)
        {
            _employeeTimesheetService.Update(model);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
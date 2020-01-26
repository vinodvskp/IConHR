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
    public class DepartmentApiController : BaseApiController
    {
        private readonly IDepartmentService _departmentService = null;
        public DepartmentApiController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public int Post([FromBody]DepartmentModel model)
        {
            model.Status = true;
            return _departmentService.SaveDepartment(model);
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
        [Route("api/departmentapi/departmentNames")]
        [ActionName("departmentNames")] //
        public IEnumerable<ChoiceOptionModel> DepartmentNames()
        {
            return _departmentService.GetDepartments();
        }
    }
}
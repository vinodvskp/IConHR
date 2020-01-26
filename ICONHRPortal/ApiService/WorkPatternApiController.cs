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
    public class WorkPatternApiController : BaseApiController
    {
        private readonly IWorkPatternService _workPatternService = null;
        public WorkPatternApiController(IWorkPatternService workPatternService)
        {
            _workPatternService = workPatternService;
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
        public int Post([FromBody]WorkPatternModel model)
        {
            return _workPatternService.SaveWorkPattern(model);
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
        [Route("api/workpatternApi/workPatternsOptions")]
        [ActionName("workPatternsOptions")] //
        public IEnumerable<ChoiceOptionModel> workPatternsOptions()
        {
            return _workPatternService.GetWorkPatternsOptions();
        }
    }
}
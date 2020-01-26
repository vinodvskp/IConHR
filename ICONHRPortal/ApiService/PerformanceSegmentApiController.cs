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
    public class PerformanceSegmentApiController : ApiController
    {
        private readonly IPerformanceSegmentService _performanceSegmentService = null;
        public PerformanceSegmentApiController(IPerformanceSegmentService performanceSegmentService)
        {
            _performanceSegmentService = performanceSegmentService;
        }
        // GET api/<controller>
        public IEnumerable<PerformanceSegmentModel> Get()
        {
            return _performanceSegmentService.GetPerformancesegments();
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

        [HttpGet]
        [Route("api/PerformanceSegmentApi/Ratings")]
        [ActionName("Ratings")] //
        public IEnumerable<PerformanceScoreModel> Ratings()
        {
            return _performanceSegmentService.GetPerformanceScoreRatings();
        }
    }
}
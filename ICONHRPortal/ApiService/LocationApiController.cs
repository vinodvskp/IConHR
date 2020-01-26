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
    public class LocationApiController : BaseApiController
    {
        private readonly ILocationService _locationService = null;

        public LocationApiController(ILocationService locationService)
        {
            _locationService = locationService;
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
        public int Post([FromBody]LocationModel model)
        {
            model.CompanyId = base.CompanyId;
           return _locationService.SaveLocation(model);
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
        [Route("api/locationapi/locationNames")]
        [ActionName("locationNames")] //
        public IEnumerable<ChoiceOptionModel> LocationNames()
        {
            return _locationService.GetLocations();
        }
    }
}
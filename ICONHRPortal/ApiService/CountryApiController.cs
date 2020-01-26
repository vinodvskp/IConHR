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
    public class CountryApiController : ApiController
    {
        private ICountryService _countryService = null;
        public CountryApiController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        // GET api/<controller>
        public IEnumerable<ChoiceOptionModel> Get()
        {
            return _countryService.GetCountries();
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
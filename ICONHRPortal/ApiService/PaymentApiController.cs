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
    [AllowAnonymous]
    public class PaymentApiController : ApiController
    {
        private readonly IPaymentService _paymentService = null;
        public PaymentApiController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
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
        public void Post([FromBody]CreditCardDetailModel model)
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
        [Route("api/paymentapi/CountryCardDetails")]
       // [ActionName("ClientNames")]
        public CountryCardDetailsModel CountryCardDetails()
        {
            return _paymentService.GetCountryCardDetails();
        }
    }
}
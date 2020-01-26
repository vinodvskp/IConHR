using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Extensions;
using ICONHRPortal.Model;

namespace ICONHRPortal.ApiService
{
  
    public class EmployeeLogBookApiController : BaseApiController
    {
        private readonly IEmployeeLogBookService _employeeLogBookService = null;

        public EmployeeLogBookApiController(IEmployeeLogBookService employeeLogBookService)
        {
            _employeeLogBookService = employeeLogBookService;
        }

        // GET api/<controller>
        public IEnumerable<EmployeeLogBookModel> GetEmployeeLogBookByType(string type)
        {
            return _employeeLogBookService.GetEmployeeLogBookByType(type);
        }
        public EmployeeLogBookModel GetById(int id)
        {
            return _employeeLogBookService.GetById(id);
        }
        //[System.Web.Http.Route("api/employeelogbookapi/DownLoadDoucument")]
        //[System.Web.Http.ActionName("DownLoadDoucument")]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage DownLoadDoucument(int id)
        {
            var obj = _employeeLogBookService.GetById(id);
            // string reqBook = format.ToLower() == "pdf" ? bookPath_Pdf : (format.ToLower() == "xls" ? bookPath_xls : (format.ToLower() == "doc" ? bookPath_doc : bookPath_zip));
            string bookName = obj.DocName.ToLower();

            //converting Pdf file into bytes array  
            byte[] fileBytes = (byte[])obj.DocFile;
            var stream = new MemoryStream(fileBytes);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = obj.DocName
            };
            return response;
        }
        // GET api/<controller>
        public IEnumerable<EmployeeLogBookModel> Get(int empId , string type)
        {
            if(empId == 0)
               empId = Convert.ToInt32(UserIdentity);
            return _employeeLogBookService.GetEmployeeLogBooks(empId, type);
        }



        // POST api/<controller>
        public void Post([FromBody]EmployeeLogBookModel model)
        {

            if (model.EmpId == 0)
                model.EmpId = Convert.ToInt32(UserIdentity);
            if (!string.IsNullOrEmpty(model.Data))
            {
                byte[] dataInByteArray = Convert.FromBase64String(model.Data.Replace("data:" + model.DocType + ';', "").Replace("base64,", ""));
                model.DocFile = dataInByteArray;
            }
          
            if (model.LogBookID == 0)
            {
                model.CreatedBy = UserName;
                model.CreatedDate = DateTime.Now;
                model.LastUpdatedBy = UserName;
                model.LastUpdatedDate = DateTime.Now;
                _employeeLogBookService.Save(model);
            }
            else
            {
                model.LastUpdatedBy = UserName;
                model.LastUpdatedDate = DateTime.Now;
                _employeeLogBookService.Update(model);
            }
        }

        // PUT api/<controller>/5
        public void Put([FromBody]EmployeeLogBookModel model)
        {
            _employeeLogBookService.Update(model);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _employeeLogBookService.Delete(id);
        }
    }
}
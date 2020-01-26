using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Extensions;
using ICONHRPortal.Model;

namespace ICONHRPortal.ApiService
{
    public class DocumentApiController : BaseApiController
    {
        private readonly IDocumentService _documentService = null;

        public DocumentApiController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET api/<controller>
        public IEnumerable<DocumentModel> Get()
        {
            string path = HttpContext.Current.Server.MapPath("~/Documents/");
            var documents = _documentService.GetDocuments();
            foreach (var doc in documents)
            {
                doc.FilePath = path + doc.DocumentName;
            }

            return documents;
        }

        // GET api/<controller>/5
        public IEnumerable<DocumentModel> Get(string fromScreen, int employeeId = 0)
        {
            if (employeeId == 0) // 0 means logged id expecting !=0 means selected employee id expecting
            {
                employeeId = int.Parse(base.UserIdentity);
            }
            int companyId = base.CompanyId;
            string path = HttpContext.Current.Server.MapPath("~/Documents/");
            var documents = _documentService.GetDocuments(employeeId, companyId,fromScreen);
            foreach (var doc in documents)
            {
                doc.FilePath = path + doc.DocumentName;
            }

            return documents;
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] DocumentModel model)
        {
            //Send OK Response to Client.
            model.CompanyId = base.CompanyId;
            if (model.EmpID == null || model.EmpID == 0)
            {
                model.EmpID = int.Parse(base.UserIdentity);
            }
            model.DocumentAddedDate = DateTime.Now;
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = base.User.GetName();
            model.Status = true;
            _documentService.SaveDocument(model);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT api/<controller>/5
        public void Put([FromBody] DocumentModel model)
        {
            _documentService.UpdateDocument(model);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _documentService.DeleteDocument(id);
        }

        [HttpGet]
        [Route("api/documentapi/DocumentType")]
        [ActionName("DocumentType")]
        //
        public IEnumerable<ChoiceOptionModel> DocumentType()
        {
            return _documentService.GetDocumentCategoryTypes();
        }

        [Route("api/documentapi/UploadFiles")]
        [HttpPost]
        public HttpResponseMessage UploadFiles()
        {
            //Create the Directory.
            string path = HttpContext.Current.Server.MapPath("~/Documents/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Save the Files.
            foreach (string key in HttpContext.Current.Request.Files)
            {
                HttpPostedFile postedFile = HttpContext.Current.Request.Files[key];
                postedFile.SaveAs(path + postedFile.FileName);
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
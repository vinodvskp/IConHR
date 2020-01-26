using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICONHRPortal.Controllers
{
    public class BulkActionsController : BaseMVCController
    {
        // GET: BulkActions
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult EmployeeBulkUpload()
        {
            return PartialView();
        }
    }
}
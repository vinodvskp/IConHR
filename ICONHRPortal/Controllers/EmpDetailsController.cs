using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICONHRPortal.Controllers
{
    public class EmpDetailsController : BaseMVCController
    {
        // GET: EmpDetails
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Documents()
        {
            return PartialView();
        }

        public PartialViewResult Planner()
        {
            return PartialView();
        }

        public PartialViewResult Performance()
        {
            return PartialView();
        }

    }
}
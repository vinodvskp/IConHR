using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICONHRPortal.Controllers
{
    public class PlannerController : BaseMVCController
    {
        // GET: Planner
        public ActionResult Index()
        {
            return View();
        }
    }
}
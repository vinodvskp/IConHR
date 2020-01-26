using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICONHRPortal.Controllers
{
    public class SettingsController : BaseMVCController
    {
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HolidayAbsenceSetting()
        {
            return PartialView();
        }

        public PartialViewResult CompanySetting()
        {
            return PartialView();
        }

        public PartialViewResult AdministratorSetting()
        {
            return PartialView();
        }

        public PartialViewResult PerformanceReviewSetting()
        {
            return PartialView();
        }
    }
}
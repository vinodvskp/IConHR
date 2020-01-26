using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICONHRPortal.Controllers
{
    public class MessageController : BaseMVCController
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
    }
}
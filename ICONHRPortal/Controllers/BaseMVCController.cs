using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICONHRPortal.Extensions;

namespace ICONHRPortal.Controllers
{
    [Authorize]
    public class BaseMVCController : Controller
    {
        protected int LoggedInUserId
        {
            get
            {
                return int.Parse( HttpContext.User.Identity.GetUserById());
            }
        }
    }
}
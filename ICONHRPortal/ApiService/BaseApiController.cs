using ICONHRPortal.Extensions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ICONHRPortal.ApiService
{
    [Authorize] //TODO
    public class BaseApiController : ApiController
    {
        public string UserIdentity
        {
            get
            {
                var userId = HttpContext.Current.User.Identity.GetUserById();
                return userId;
            }
        }
        public int ReportingManagerId
        {
            get
            {
                var reportManagerId = HttpContext.Current.User.Identity.GetRepMgrID();
                if (reportManagerId != "")
                    return int.Parse(reportManagerId);
                else
                    return 0;

            }
        }

        public int DepartmentId
        {
            get
            {
                var departmentId = HttpContext.Current.User.Identity.GetDepartmentId();
                if (departmentId != "")
                    return int.Parse(departmentId);
                else
                    return 0;
            }
        }

        public string UserName
        {
            get
            {
                return HttpContext.Current.User.Identity.GetUserName();
            }
        }
        public int CompanyId
        {
            get
            {
                if (HttpContext.Current.User.Identity.GetCompanyId() != string.Empty)
                {
                    return int.Parse(HttpContext.Current.User.Identity.GetCompanyId());
                }

                return 0;
            }
        }

        public int LocationId
        {
            get
            {
                if (HttpContext.Current.User.Identity.LocationId() != string.Empty)
                {
                    return int.Parse(HttpContext.Current.User.Identity.LocationId());
                }

                return 1;
            }
        }

        public int LoggedInEmployeeId
        {
            get
            {
                if (HttpContext.Current.User.Identity.GetUserId() != string.Empty)
                {
                    return int.Parse(HttpContext.Current.User.Identity.GetUserId());
                }

                return 0;
            }
        }
    }
}
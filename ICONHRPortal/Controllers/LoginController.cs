using ICONHRPortal.Models;
using System;
using System.Data;
using System.Web.Mvc;
using ICONHRPortal.Data;
using ICONHRPortal.Model;

namespace ICONHRPortal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        #region Variables
        ICONHRRepository repository = new ICONHRRepository();
        EmployeeDetails empDetails = new EmployeeDetails();
        DataTable dt_LoginDetails = new DataTable(); 
        #endregion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentPage()
        {
            return View();
        }

        #region To validate user credentials
        [HttpGet]
        public bool Login(string email, string password)
        {
            var ValidateUser = false;
            repository = new ICONHRRepository();
            empDetails = new EmployeeDetails();
            dt_LoginDetails = new DataTable();
            
            try
            {
                empDetails.Email = Convert.ToString(email);
                dt_LoginDetails = repository.GetLoginDetails(empDetails);
                if (dt_LoginDetails!=null && dt_LoginDetails.Rows.Count > 0)
                {
                   bool passwordValue = PasswordHash.ValidatePassword(password, "1000:" + Convert.ToString(dt_LoginDetails.Rows[0]["PasswordSalt"]) + ":" + Convert.ToString(dt_LoginDetails.Rows[0]["PasswordHash"]));
                                
                    if (passwordValue)
                    {
                        Session["EmpID"] = Convert.ToString(dt_LoginDetails.Rows[0]["EmpID"]);
                        Session["EmpName"] = Convert.ToString(dt_LoginDetails.Rows[0]["EmpName"]);
                        Session["EmpRole"] = Convert.ToString(dt_LoginDetails.Rows[0]["EmpRoleID"]);
                        Session["CompanyName"] = Convert.ToString(dt_LoginDetails.Rows[0]["CompanyName"]);
                        Session["RepMgrID"] = Convert.ToString(dt_LoginDetails.Rows[0]["RepMgrID"]);
                        ValidateUser = true;
                    }
                }
                else
                {
                    ValidateUser = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                var frame = trace.FrameCount > 1 ? trace.GetFrame(1) : trace.GetFrame(0);
                int Line = (int)frame.GetFileLineNumber();
                string methodName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                LogClass.CreateLogXml(ex.Message, controllerName, Convert.ToString(ex.InnerException), methodName, Line);
            }

            return ValidateUser;
        }
        #endregion
    }
}
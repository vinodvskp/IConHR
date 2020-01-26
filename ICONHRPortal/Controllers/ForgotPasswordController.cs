using System;
using System.Text;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Web;
using ICONHRPortal.Models;
using ICONHRPortal.Data;
using ICONHRPortal.Model;

namespace ICONHRPortal.Controllers
{
    public class ForgotPasswordController : BaseMVCController
    {
        // GET: ForgotPassword
        #region Variables 
        string webAddress = ConfigurationManager.AppSettings["ICONHRUrl"];
        ICONHRRepository repository = new ICONHRRepository();
        EmployeeDetails empDetails = new EmployeeDetails();
        string responseMsg = string.Empty;
        #endregion
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }
        //[HttpGet]
        //public string ForgotPassword(string emailAddress)
        //{
        //    DataTable dt_ForgotPassword = new DataTable();
        //    repository = new ICONHRRepository();
        //    empDetails = new EmployeeDetails();
        //    string szBody = string.Empty;
        //    string EmployeeName = string.Empty;
        //    string url = string.Empty;
        //    responseMsg = string.Empty;           

        //    try
        //    {
        //        string RandomToken = RandomString(12, true);
        //        empDetails.Email = Convert.ToString(emailAddress).Trim();
        //        empDetails.PasswordToken = RandomToken;
        //        dt_ForgotPassword  = repository.ForgotPassword(empDetails);
        //        if (dt_ForgotPassword !=null && dt_ForgotPassword.Rows.Count > 0)
        //        {                      
        //            EmployeeName = Convert.ToString(dt_ForgotPassword.Rows[0]["EmpName"]).Trim();
        //            url = "<a href='" + webAddress + "/ResetPassword?T=" + RandomToken + "'>Reset Password</a>";
        //            szBody = Mailtemplate.PrepareMailBodyWith("ResetPassword.html",
        //            "URL", url,                     
        //            "EmployeeName", EmployeeName.ToUpper());
        //            Mail email = new Mail();
        //            email.SendEmail("ICON HR - Reset Password", szBody, emailAddress);
        //            responseMsg = "Success";
        //        }                                       
        //        else
        //        {
        //            responseMsg = "False";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //        var frame = trace.FrameCount > 1 ? trace.GetFrame(1) : trace.GetFrame(0);
        //        int Line = (int)frame.GetFileLineNumber();
        //        string methodName = this.ControllerContext.RouteData.Values["action"].ToString();
        //        string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
        //        LogClass.CreateLogXml(ex.Message, controllerName, Convert.ToString(ex.InnerException), methodName, Line);
        //    }

        //    return responseMsg;
        //}
        //private string RandomString(int size, bool lowerCase)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    Random random = new Random();
        //    char ch;
        //    for (int i = 1; i < size + 1; i++)
        //    {
        //        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        //        builder.Append(ch);
        //    }
        //    if (lowerCase)
        //        return builder.ToString().ToLower();
        //    else
        //        return builder.ToString();
        //}
    }

    public class RestPasswordController : BaseMVCController
    {
       
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
   
        
    }
}
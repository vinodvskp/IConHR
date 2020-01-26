using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICONHRPortal.Model;
using ICONHRPortal.Data;
using ICONHRPortal.Models;

namespace ICONHRPortal.Controllers
{
    public class ResetPasswordController : BaseMVCController
    {
        #region Variables
        ICONHRRepository repository = new ICONHRRepository();
        EmployeeDetails empDetails = new EmployeeDetails();
        string randomToken = string.Empty;
        string responseMsg = string.Empty;
        #endregion

        // GET: ResetPassword
        public ActionResult Index()
        {
            repository = new ICONHRRepository();
            empDetails = new EmployeeDetails();
            responseMsg = string.Empty;

            try
            {
                if (Request["T"] != null)
                {
                    empDetails.PasswordToken = Convert.ToString(Request["T"]).Trim();
                    responseMsg = repository.CheckPasswordToken(empDetails);                    
                    if (responseMsg.Trim().ToLower() == "fail")
                    {
                        TempData["ErrorMessage"] = "Reset password link expired";
                        return RedirectToAction("Index", "Message");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login");
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
            
            return View();
        }

        #region To reset password
        //[HttpGet]
        //public string ResetPassword(string password, string passwordToken)
        //{
        //    repository = new ICONHRRepository();
        //    empDetails = new EmployeeDetails();
        //    responseMsg = string.Empty;

        //    try
        //    {
        //        if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(passwordToken))
        //        {
        //            password = PasswordHash.CreateHash(password);
        //            string[] myPassword = password.Split(':');
        //            empDetails.PasswordToken = passwordToken;
        //            empDetails.PasswordSalt = Convert.ToString(myPassword[1]).Trim();
        //            empDetails.PasswordHash = Convert.ToString(myPassword[2]).Trim();
        //            responseMsg = repository.ResetPassword(empDetails);
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
        #endregion 
    }
}
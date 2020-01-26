using System;
using System.Configuration;
using System.Web.Mvc;
using ICONHRPortal.Model;
using ICONHRPortal.Data;
using ICONHRPortal.Models;

namespace ICONHRPortal.Controllers
{
    public class RegistrationController : BaseMVCController
    {
        // GET: Registration

        #region Variables
        string response = Convert.ToString(ConfigurationManager.AppSettings["response"]);
        ICONHRRepository repository = new ICONHRRepository();
        EmployeeDetails empDetails = new EmployeeDetails();
        string responseMsg = string.Empty;
        #endregion
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        #region To add new employee details 
        [HttpPost]
        public string AddNewEmpDetails(string empName, string email, string phoneNumber, string password, string company, string companySize)
        {
            empDetails = new EmployeeDetails();
            responseMsg = string.Empty;
            string passwordHashSalt = string.Empty;            

            try
            {
                #region Password Encryption
                passwordHashSalt = PasswordHash.CreateHash(password);
                string[] passwordValues = passwordHashSalt.Split(':');
                #endregion
                empDetails.Emp_Name = empName;
                empDetails.Emp_Role = 1;
                empDetails.Email = email;
                empDetails.PhoneNumber = phoneNumber;
                empDetails.PasswordSalt = password; //Convert.ToString(passwordValues[1]).Trim();
                //empDetails.PasswordHash = Convert.ToString(passwordValues[2]).Trim();
                empDetails.Company_Name = company;
                empDetails.Company_Size = companySize;
                empDetails.Created_By = empName;
                
                responseMsg = repository.CheckEmailId(empDetails);

                if (responseMsg == response)
                {
                    Session["EmployeeModel"] = empDetails;
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

            return responseMsg;
        }
        #endregion
    }
}
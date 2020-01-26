using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data;
using ICONHRPortal.Extensions;
using ICONHRPortal.Model;
using ICONHRPortal.Models;
using Microsoft.AspNet.Identity;

namespace ICONHRPortal.ApiService
{
    public class UserApiController : BaseApiController
    {
        private readonly IEmployeeDetailsService _employeeDetailsService = null;
        public UserApiController(IEmployeeDetailsService employeeDetailsService)
        {
            _employeeDetailsService = employeeDetailsService;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string GetProfilePhoto()
        {
            string loggedInuserid = UserIdentity;
            if (!string.IsNullOrEmpty(loggedInuserid))
            {
                var empdetail =_employeeDetailsService.GetEmployeeDetailsById(int.Parse(loggedInuserid));
                if(empdetail != null)
                {
                    byte[] imageBites = empdetail.ProfilePhoto;
                    return Base64EncodeBytes(imageBites);
                }
            }
            return string.Empty;

        }
        public string GetMagerProfilePhoto()
        {
            string loggedInuserid = ReportingManagerId.ToString();
            if (!string.IsNullOrEmpty(loggedInuserid))
            {
                var empdetail = _employeeDetailsService.GetEmployeeDetailsById(int.Parse(loggedInuserid));
                if (empdetail != null)
                {
                    byte[] imageBites = empdetail.ProfilePhoto;
                    return Base64EncodeBytes(imageBites);
                }
            }
            return string.Empty;

        }
        [HttpPost]
        [Route("api/userapi/ForgotPassword")]
        [ActionName("ForgotPassword")]
        [AllowAnonymous]
        public string ForgotPassword([FromBody]ResetPasswordModel model)
        {
            DataTable dt_ForgotPassword = new DataTable();
            var repository = new ICONHRRepository();
            var empDetails = new EmployeeDetails();
            string szBody = string.Empty;
            string EmployeeName = string.Empty;
            string url = string.Empty;
            string webAddress = ConfigurationManager.AppSettings["ICONHRUrl"];
            var responseMsg = string.Empty;

            try
            {
                string RandomToken = RandomString(12, true);
                empDetails.Email = Convert.ToString(model.Email).Trim();
                empDetails.PasswordToken = RandomToken;
                dt_ForgotPassword = repository.ForgotPassword(empDetails);
                if (dt_ForgotPassword != null && dt_ForgotPassword.Rows.Count > 0)
                {
                    EmployeeName = Convert.ToString(dt_ForgotPassword.Rows[0]["EmpName"]).Trim();
                    url = "<a href='" + webAddress + "/ResetPassword?T=" + RandomToken + "'>Reset Password</a>";
                    szBody = Mailtemplate.PrepareMailBodyWith("ResetPassword.html",
                    "URL", url,
                    "EmployeeName", EmployeeName.ToUpper());
                    Mail email = new Mail();
                    email.SendEmail("ICON HR - Reset Password", szBody, model.Email);
                    responseMsg = "Success";
                }
                else
                {
                    responseMsg = "False";
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

        [HttpPost]
        [Route("api/userapi/ResetPassword")]
        [ActionName("ResetPassword")] //
        [AllowAnonymous]
        public string ResetPassword([FromBody]ResetPasswordModel model)
        {
            var repository = new ICONHRRepository();
            var empDetails = new EmployeeDetails();
            empDetails.Email = model.Email;
            string responseMsg = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(model.Password))
                {
                    //model.Password = PasswordHash.CreateHash(model.Password);
                    
                    empDetails.Password = model.Password;
                    empDetails.PasswordSalt = model.Password;
                    empDetails.PasswordHash = model.Password;
                    responseMsg = repository.ResetPassword(empDetails);
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

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 1; i < size + 1; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            else
                return builder.ToString();
        }


        private static string Base64EncodeBytes(byte[] inputBytes)
        {
            // Each 3-byte sequence in inputBytes must be converted to a 4-byte 
            // sequence 
            long arrLength = (long)(4.0d * inputBytes.Length / 3.0d);
            if ((arrLength % 4) != 0)
            {
                // increment the array length to the next multiple of 4 
                //    if it is not already divisible by 4
                arrLength += 4 - (arrLength % 4);
            }

            char[] encodedCharArray = new char[arrLength];
            Convert.ToBase64CharArray(inputBytes, 0, inputBytes.Length, encodedCharArray, 0);

            return (new string(encodedCharArray));
        }
    }
}
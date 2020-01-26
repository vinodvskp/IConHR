using System;
using System.Data;
using System.Web.Mvc;
using ICONHRPortal.Model;
using ICONHRPortal.Data;
using ICONHRPortal.Extensions;
using ICONHRPortal.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace ICONHRPortal.Controllers
{
    public class DashboardController : BaseMVCController
    {
        // GET: Dashboard
        #region Variables 
        ICONHRRepository repository = new ICONHRRepository();
        EmployeeDetails empDetails = new EmployeeDetails();
        string responseMsg = string.Empty;
        #endregion
        public ActionResult Index()
        {
            return View();
        }

        #region To change password
        [HttpGet]
        public string ChangePassword(string oldPassword, string password)
        {
           repository = new ICONHRRepository();
           empDetails = new EmployeeDetails();
           DataTable dt_OldPwdDetails = new DataTable();
           responseMsg = string.Empty;
           bool oldPasswordExists = false;

            try
            {
                if (Session["EmpID"] != null)
                {
                    empDetails.Emp_ID = Convert.ToInt32(Session["EmpID"]);
                    dt_OldPwdDetails = repository.GetLoginDetailsByEmpId(empDetails);

                    if (dt_OldPwdDetails.Rows.Count > 0)
                    {
                        oldPasswordExists = PasswordHash.ValidatePassword(oldPassword, "1000:" + Convert.ToString(dt_OldPwdDetails.Rows[0]["PasswordSalt"]) + ":" + Convert.ToString(dt_OldPwdDetails.Rows[0]["PasswordHash"]));
                    }                       

                    if (oldPasswordExists)
                    {
                        repository = new ICONHRRepository();
                        password = PasswordHash.CreateHash(Convert.ToString(password).Trim());
                        string[] myNewPwd = password.Split(':');
                        empDetails.PasswordSalt = Convert.ToString(myNewPwd[1]).Trim();
                        empDetails.PasswordHash = Convert.ToString(myNewPwd[2]).Trim();
                        empDetails.Emp_ID = Convert.ToInt32(Session["EmpID"]);
                        empDetails.Last_Updated_By = Convert.ToString(Session["EmpName"]).Trim();

                        responseMsg = repository.ChangePassword(empDetails);                       
                    }
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

        #region To add Employee details 
        [HttpGet]
        public string AddEmployeeDetails(string empName, string email, string phoneNumber, string password, string company, string companySize, string profilePhoto)
        {
            empDetails = new EmployeeDetails();
            string passwordHashSalt = string.Empty;
            int empId = 0;

            try
            {
                #region Password Encryption
                passwordHashSalt = PasswordHash.CreateHash(password);
                string[] passwordValues = passwordHashSalt.Split(':');
                #endregion
                var PhotoBase64= System.Convert.FromBase64String(profilePhoto);
                empDetails.Emp_Name = empName;
                empDetails.Emp_Role = 2;
                empDetails.Email = email;
                empDetails.PasswordSalt = password; //Convert.ToString(passwordValues[1]).Trim();
                empDetails.PasswordHash = Convert.ToString(passwordValues[2]).Trim();
                empDetails.PhoneNumber = phoneNumber;
                empDetails.Gender = "";
                empDetails.DOB = "";
                empDetails.ProfilePhoto = PhotoBase64;
                empDetails.Company_Name = Convert.ToString(Session["CompanyName"]);
                empDetails.Address = "";
                empDetails.Country_ID = 1;
                empDetails.PostalCode = "";
                empDetails.Created_By = Convert.ToString(Session["EmpName"]);                
                responseMsg = repository.AddNewEmpDetails(empDetails);
                string[] response = responseMsg.Split(',');
                if (response.Length == 2)
                {
                    responseMsg = Convert.ToString(response[0]);                   
                }
                else
                {
                    responseMsg = "Fail";
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

        #region To get the job information details
        [HttpGet]
        public string GetDeptJobRolesRpMgrDetails()
        {
            repository = new ICONHRRepository();
            DataSet ds_DeptJobRolesRpMgrDetails = new DataSet();
            string data = string.Empty;

            try
            {
                ds_DeptJobRolesRpMgrDetails = repository.GetDeptJobRolesRpMgrDetails();
                data = JsonConvert.SerializeObject(ds_DeptJobRolesRpMgrDetails);
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

            return data;
        }
        #endregion

        public string GetProfileImage()
        {
            repository = new ICONHRRepository();
            DataSet dt = new DataSet();
            string data = string.Empty;
            int employeeId = 0;

            if (Session["EmpID"] != null)
            {
                employeeId = int.Parse(Session["EmpID"].ToString());
            }
            else
            {
                return string.Empty;
            }

            try
            {
                byte[] logo = repository.GetProfileImageById(employeeId);
                // data = JsonConvert.SerializeObject(dt);
                // byte[] byt = Convert.FromBase64String("aQBWAEIATwBSAHcAMABLAEcAZwBvAEEAQQBBAEEA");
                string imgData = Base64EncodeBytes(logo);
                string base64String = Convert.ToBase64String(logo);
                return imgData;
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

            return data;
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
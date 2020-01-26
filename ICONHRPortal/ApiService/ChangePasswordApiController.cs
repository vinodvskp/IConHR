using ICONHRPortal.Data;
using ICONHRPortal.Model;
using ICONHRPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ICONHRPortal.ApiService
{
    public class ChangePasswordApiController : BaseApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public string Post(ChangePasswordModel model)
        {
            var repository = new ICONHRRepository();
            var empDetails = new EmployeeDetails();
            DataTable dt_OldPwdDetails = new DataTable();
            string responseMsg = string.Empty;
            bool oldPasswordExists = false;

            try
            {
                if (!string.IsNullOrEmpty(UserIdentity))
                {
                    empDetails.Emp_ID = Convert.ToInt32(UserIdentity);
                    dt_OldPwdDetails = repository.GetLoginDetailsByEmpId(empDetails);

                    if (dt_OldPwdDetails.Rows.Count > 0)
                    {
                        //oldPasswordExists = PasswordHash.ValidatePassword(model.OldPassword, "1000:" + Convert.ToString(dt_OldPwdDetails.Rows[0]["PasswordSalt"]) + ":" + Convert.ToString(dt_OldPwdDetails.Rows[0]["PasswordHash"]));
                        oldPasswordExists = Convert.ToString(dt_OldPwdDetails.Rows[0]["PasswordSalt"]) ==
                                            model.OldPassword;
                    }

                    if (model.OldPassword == dt_OldPwdDetails.Rows[0]["PasswordSalt"].ToString())
                    {
                        repository = new ICONHRRepository();
                        //model.NewPassword = PasswordHash.CreateHash(Convert.ToString(model.NewPassword).Trim());
                       // string[] myNewPwd = model.NewPassword.Split(':');
                        empDetails.PasswordSalt = model.NewPassword; //myNewPwd[1]; //Convert.ToString(myNewPwd[1]).Trim();
                        //empDetails.PasswordHash = Convert.ToString(myNewPwd[2]).Trim();
                        empDetails.Emp_ID = Convert.ToInt32(UserIdentity);
                        empDetails.Last_Updated_By = Convert.ToString(UserIdentity).Trim(); // TODO it shold not be id instead use name

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

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
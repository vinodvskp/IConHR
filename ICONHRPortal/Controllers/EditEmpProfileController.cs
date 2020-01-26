using System;
using System.Data;
using System.IO;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using ICONHRPortal.Data;
using ICONHRPortal.Model;

namespace ICONHRPortal.Controllers
{
    public class EditEmpProfileController : BaseMVCController
    {
        ICONHRRepository repository = new ICONHRRepository();
        EmployeeDetails empDetails = new EmployeeDetails();
        string responseMsg = string.Empty;
        // GET: EditEmpProfile
        public ActionResult Index()
        {
            DataTable dtEmployeeDetails = new DataTable();
            dtEmployeeDetails = repository.GetEmployeeDetailsByEmpId(Convert.ToInt32(Session["EmpID"]));
            ViewBag.CountriesList= repository.getCountryDetails();
            return View(dtEmployeeDetails);
        }

        [HttpPost]
        public ContentResult FileUpload(HttpPostedFileBase file)
        {
            //if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"),
                                               Path.GetFileName(file.FileName));
                    if (!System.IO.Directory.Exists(Server.MapPath("~/Uploads")))
                    {
                        DirectorySecurity securityRules = new DirectorySecurity();
                        securityRules.AddAccessRule(new FileSystemAccessRule(@"Users", FileSystemRights.FullControl, AccessControlType.Allow));
                        //securityRules.AddAccessRule(new FileSystemAccessRule(@"Domain\Users", FileSystemRights.FullControl, AccessControlType.Allow));

                        DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/Uploads"), securityRules);
                       // System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads"));
                    }
                   
                    file.SaveAs(path);
                    return Content("Success");
                    //ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    return Content("Error");
                    // ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            //else
            //{
            //    return Content("You have not specified a file");
            //    // ViewBag.Message = "You have not specified a file.";
            //}
        }
        [HttpPost]
        public string EditEmployee(string firstName, string lastName, string email, string phone, string gender, string upload,string address,string dob,string postalCode,int country)
        {
            responseMsg = string.Empty;
            try
            {
                var profilePhoto =  System.Convert.FromBase64String(upload);
                empDetails = new EmployeeDetails
                {
                    Emp_ID = Convert.ToInt32(Session["EmpID"]),
                    Emp_Name = firstName + " " + lastName,
                    Email = email,
                    PhoneNumber = phone,
                    Gender = gender,
                    Address = address,
                    ProfilePhoto = profilePhoto,
                    DOB=dob,
                    PostalCode=postalCode,
                    Country_ID=country
                };
                responseMsg = repository.UpdateEmpDetailsByEmpId(empDetails);
            }
            catch(Exception ex)
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

        }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Model;
using ICONHRPortal.Models;

namespace ICONHRPortal.ApiService
{
    public class EmployeeApiController : BaseApiController
    {
        private readonly IEmployeeDetailsService _employeeDetailsService = null;
        private readonly ICompanyDetailService _companyDetailService = null;
        private SqlConnection sqlConn;

        public EmployeeApiController(IEmployeeDetailsService employeeDetailsService, ICompanyDetailService companyDetailService)
        {
            _employeeDetailsService = employeeDetailsService;
            _companyDetailService = companyDetailService;
            string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
        }
        // GET api/<controller>
        public IEnumerable<EmployeeDetailsModel> Get()
        {
            int mgrId = base.ReportingManagerId;
            if (mgrId == 0)
            {
                mgrId = Convert.ToInt16(base.UserIdentity);
            }
            return _employeeDetailsService.GetEmployeeDetailsModels(mgrId);
        }

        // GET api/<controller>/5 Me Section
        public EmployeeDetailsModel Get(int id)
        {
            return _employeeDetailsService.GetEmployeeDetailsById(int.Parse(UserIdentity));
        }
        [HttpGet]
        [Route("api/employeeApi/GetEmployee")]
        [ActionName("GetEmployee")] //
        public EmployeeDetailsModel GetEmployee()
        {
            return _employeeDetailsService.GetEmployee(int.Parse(UserIdentity));
        }
        public IList<EmployeeDetailsModel> GetAdminDetails()
        {
            return _employeeDetailsService.GetAdminDetails();
        }

        private int SaveCompanyDetails(string CompanyName)
        {
            int CompanyId = 0;
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["SqlConn"].ToString()));
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.Insert_Update_company_details_sp";
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@CompanySize", "50");
            cmd.Parameters.AddWithValue("@IsActive", 0);
            cmd.Parameters.AddWithValue("@IsTrailEnd", 0);
            cmd.Parameters.AddWithValue("@IsPaid", 0);

            cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
            cmd.Parameters["@CompanyID"].Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                //Storing the output parameters value in 3 different variables.  
                CompanyId = Convert.ToInt32(cmd.Parameters["@CompanyID"].Value);
                // Here we get all three values from database in above three variables.  
            }
            catch (Exception ex)
            {
                // throw the exception  
            }
            finally
            {
                conn.Close();
            }
            return CompanyId;
        }
        // POST api/<controller>
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody]EmployeeDetailsModel model) // TODO first & last combine it
        {

            if (model.CompanyID == null && !model.IsNewRecord)
            {
                List<CompanyDetailModel> companyDetails = _companyDetailService.GetCompanyDetails().ToList();
                foreach (var company in companyDetails)
                {
                    if (company.CompanyName != null)

                    {
                        if (company.CompanyName.Trim().ToUpper() == model.CompanyName.Trim().ToUpper())
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Result = "company already exists!" });
                        }
                    }
                }

                if (_employeeDetailsService.HasEmailIdExists(model.EmailID))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Result = "Email Id already exists!" });
                }

                if (_employeeDetailsService.HasCompanyUrlxists(model.CompanyUrl))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Result = "Company URL already exists!" });
                }

                model.CompanyID = SaveCompanyDetails(model.CompanyName);
            }
            //string passwordHashSalt = string.Empty;
            //passwordHashSalt = PasswordHash.CreateHash("");
           // string[] passwordValues = passwordHashSalt.Split(':');
            //model.PasswordSalt = Convert.ToString(passwordValues[1]).Trim();
            //model.PasswordHash = Convert.ToString(passwordValues[2]).Trim();
            model.PasswordSalt = model.Password;
            model.CreatedBy = User.Identity.Name;
            model.CreatedDate = DateTime.Now;
            if (model.CompanyID == null || model.CompanyID == 0)
            {
                model.CompanyID = CompanyId;
            }

            //List<tblEmployeeJobDetailsModel> list = new List<tblEmployeeJobDetailsModel>();
            //list.Add(model.objtblEmployeeJobDetails);
            //model.tblEmployeeJobDetails = list;
            model.Status = true;
            if (_employeeDetailsService.HasEmailIdExists(model.EmailID))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Result = "Email Id already exists!" });
            }
            int result = _employeeDetailsService.SaveEmployee(model);
            // while registration company url is mandartory and send email based on registration
            if (model.CompanyUrl == "" || model.CompanyUrl == null)
            {
                SendEmail(model, "Email id has been created");
            }
            else
            {
                SendEmail(model, "ICon HR Registration has been Sucessfull");
            }
            if (result > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, new { Result = "Success" });
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "error");
        }

        // PUT api/<controller>/5
        public int Put([FromBody]EmployeeDetailsModel model)
        {
            model.EmpID = int.Parse(UserIdentity);
            model.LastUpdatedDate =DateTime.Now;

            if (model.ProfilePhotoBase64 != null)
            {
                model.ProfilePhoto = System.Convert.FromBase64String(model.ProfilePhotoBase64);
            }

            return _employeeDetailsService.UpdateEmployee(model);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/employeeApi/employeeNames")]
        [ActionName("employeeNames")] //
        public IEnumerable<ChoiceOptionModel> EmployeeNames()
        {
            return _employeeDetailsService.GetEmplyeeNamesByCompanyId(base.CompanyId);
        }

        [HttpPost]
        [Route("api/employeeApi/EmployeeBulkInsert")]
        [ActionName("EmployeeBulkInsert")] //
        public int EmployeeBulkInsert(List<EmployeeDetailsModel> employees)
        {
            int mgrId = base.ReportingManagerId;
            var employeeDetails = _employeeDetailsService.GetEmployeeDetailsModels(mgrId);
            foreach (var empDetail in employeeDetails)
            {
                bool isEmployeeEmailIdExists = employees.Where(x => x.EmailID == empDetail.EmailID).Any();
                if (isEmployeeEmailIdExists)
                {
                    throw new Exception("Email Id already exists for employee " + empDetail.EmpName);
                }

            }
            return _employeeDetailsService.SaveBulkEmployees(employees);
        }
        public IEnumerable<EmployeeNotificationModel> GetNotificaitons()
        {
            return _employeeDetailsService.GetNotificaitons();
        }
        [AllowAnonymous]
        public HttpResponseMessage updateNotificaitonStatus([FromBody]EmployeeNotificationModel model) // TODO first & last combine it
        {
            model.LastUpdatedBy = UserName;
            int result = _employeeDetailsService.updateNotificaitonStatus(model);
            if (result > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, new { Result = "Success" });
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "error");
        }
        public void SendEmail(EmployeeDetailsModel model, string subject)
        {
            //Read the SMTP settings
            SmtpClient _smtpClient = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServer"]);
            _smtpClient.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MailServerPort"]);
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailServerUserName"],
                                            System.Configuration.ConfigurationManager.AppSettings["MailServerPassword"]);

            string _fromAddress = System.Configuration.ConfigurationManager.AppSettings["FromMail"];
            string _displayName = System.Configuration.ConfigurationManager.AppSettings["SMTP_DISPLAY_NAME"];
            string _url = System.Configuration.ConfigurationManager.AppSettings["ICONHRUrl_RestPassowrd"];

            Email email = new Email();
            MailMessage _mail = new MailMessage();
            _mail.From = new MailAddress(_fromAddress, _displayName);
            string _emailTO = System.Configuration.ConfigurationManager.AppSettings["EMAIL_TO"];
            StringBuilder _body = new StringBuilder();
            _body.AppendLine("<html ><body><div style ='font-family:Calibri; font-size:15px;'>");
            _body.AppendLine("<p>Hi,</p>");
            _body.AppendLine("<p>Your account has been created please click the below click to create password</p>");
            _body.AppendLine("<p>Your emailid:<b>" + model.EmailID + "</b></p>");
            _body.AppendLine("<p>Click <a href=" + _url + model.EmailID + ">here</a> to proceed further.</p>");
            _body.AppendLine("<p>Regards,</p>");
            _body.AppendLine("" + model.CreatedBy + " <br/>");
            _body.AppendLine("</div></body></html>");

            _mail.To.Add(model.EmailID);
            _mail.Subject = subject; //"Email id has been created";
            _mail.Body = _body.ToString();
            _mail.BodyEncoding = Encoding.Unicode;
            _mail.IsBodyHtml = true;
            _smtpClient.EnableSsl = true;
            Thread threadSendMails;
            threadSendMails = new Thread(delegate ()
            {
                _smtpClient.Send(_mail);
            });
            threadSendMails.IsBackground = true;
            threadSendMails.Start();
        }
    }

    public class Email
    {
        public string Subject { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Body { get; set; }
        public IList<Attachment> attachment { get; set; }
    }

}
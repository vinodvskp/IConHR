using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Configuration;

namespace ICONHRPortal.Models
{
    public class Mail
    {
        public void SendEmail(string subject, string szBody, string EmailAddress)
        {
            try
            {
                string strMailServer = ConfigurationManager.AppSettings["MailServer"];
                int strMailServerPort = Convert.ToInt32(ConfigurationManager.AppSettings["MailServerPort"]);
                string strMailServerUserName = ConfigurationManager.AppSettings["MailServerUserName"];
                string strMailServerPassword = ConfigurationManager.AppSettings["MailServerPassword"];
                string strFromMail = ConfigurationManager.AppSettings["FromMail"];
                string strccMail = ConfigurationManager.AppSettings["ccMail"];

                #region Mail to new registered customer or new card details added customer
                string szFrom = string.Empty;
                if (!string.IsNullOrEmpty(strFromMail))
                {
                    szFrom = strFromMail;
                }
                string sztoMailID = EmailAddress;
                string szMailTo = sztoMailID;
                string szcc = string.Empty;
                MailMessage mail = new MailMessage();
                if (!string.IsNullOrEmpty(strccMail))
                {
                    szcc = strccMail;
                    mail.Bcc.Add(new MailAddress(szcc));
                }
                string szMailServer = strMailServer;
                mail.From = new MailAddress(szFrom);
                mail.To.Add(new MailAddress(szMailTo));
                mail.Subject = subject;
                mail.Body = szBody;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient(szMailServer);
                smtp.EnableSsl = false;
                smtp.Port = strMailServerPort;
                smtp.Send(mail);
                mail.Dispose();               
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
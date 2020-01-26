using System;
using System.IO;
using System.Xml;

namespace ICONHRPortal
{
    public static class LogClass
    {
        #region Implementation of CreateLogXml Method 
        public static void CreateLogXml(string errorMsg, string ControllerName, string innerHtml, string methodName, int errorLine)
        {
            try
            {
                if(!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/Logs/")))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/Logs/"));
                }

                string xmlName = "Dp_" + DateTime.Now.ToString().Replace('/', '_').Replace(':', '_') + ".xml";
                using (XmlWriter writer = XmlWriter.Create(System.Web.HttpContext.Current.Server.MapPath("~/Logs/" + xmlName)))
                {
                    String pi = "type=\"text/xsl\" href=\"Error.xsl\"";
                    writer.WriteProcessingInstruction("xml-stylesheet", pi);
                    // Write DocumentType
                    writer.WriteDocType("ErrorList", null, null, "<!ENTITY h \"Error Information\">");
                    writer.WriteStartElement("Error");
                    writer.WriteElementString("ErrorMsg", errorMsg);
                    writer.WriteElementString("ControllerName", ControllerName);
                    writer.WriteElementString("methodName", methodName);
                    writer.WriteElementString("LineNumber", Convert.ToString(errorLine));
                    writer.WriteElementString("innerExcepation", innerHtml);
                    writer.WriteEndElement();
                    LogClass.DeleteLogFiles();
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete log files 7 days before created
        public static void DeleteLogFiles()
        {
            try
            {
                string strdirName = System.Web.HttpContext.Current.Server.MapPath("~/Logs/");
                string[] files = Directory.GetFiles(strdirName);
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    DateTime strDate = DateTime.Now.AddDays(-7);
                    if (fi.CreationTime < strDate)
                        fi.Delete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
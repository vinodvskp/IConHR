using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;


namespace ICONHRPortal.Models
{
    public static class Mailtemplate
    {
        // read the text in template file and return it as a string
        public static string ReadFileFrom(string templateName)
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/MailTemplates/" + templateName);
            string body = File.ReadAllText(filePath);
            return body;
        }
        // get the template body, cache it and return the text
        public static string GetMailBodyOfTemplate(string templateName)
        {
            string cacheKey = string.Concat("mailTemplate:", templateName);
            string body;
            body = (string)System.Web.HttpContext.Current.Cache[cacheKey];
            if (string.IsNullOrEmpty(body))
            {
                //read template file text 
                body = ReadFileFrom(templateName);
                if (!string.IsNullOrEmpty(body))
                {
                    System.Web.HttpContext.Current.Cache.Insert(cacheKey, body, null, DateTime.Now.ToUniversalTime().AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            return body;
        }
        // replace the tokens in template body with corresponding values 
        public static string PrepareMailBodyWith(string templateName, params string[] pairs)
        {
            string body = GetMailBodyOfTemplate(templateName);
            for (var i = 0; i < pairs.Length; i += 2)
            {
                body = body.Replace("(:={0}:)".FormatWith(pairs[i]), pairs[i + 1]);
            }
            return body;
        }

        public static string FormatWith(this string target, params object[] args)
        {
            return string.Format(Constants.CurrentCulture, target, args);
        }

        public static class Constants
        {
            //culture info
            public static CultureInfo CurrentCulture
            {
                get
                {
                    return CultureInfo.CurrentCulture;
                }
            }
        }

        public static string PrepareMailBodyWithContent(string Content, params string[] pairs)
        {
            string body = GetMailBodyOfTemplateByContent(Content);
            for (var i = 0; i < pairs.Length; i += 2)
            {
                try
                {
                    body = body.Replace("(:={0}:)".FormatWith(pairs[i]), pairs[i + 1]);
                }
                catch
                {

                }
            }
            return body;
        }
        public static string GetMailBodyOfTemplateByContent(string Content)
        {
            string cacheKey = string.Concat("mailTemplate:", Content);
            string body;
            body = (string)System.Web.HttpContext.Current.Cache[cacheKey];
            if (string.IsNullOrEmpty(body))
            {
                //read template file text 
                body = Content;
                if (!string.IsNullOrEmpty(body))
                {
                    System.Web.HttpContext.Current.Cache.Insert(cacheKey, body, null, DateTime.Now.ToUniversalTime().AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            return body;
        }
    }
}
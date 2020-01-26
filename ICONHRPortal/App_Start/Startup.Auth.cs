using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ICONHRPortal.Providers;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Data;

namespace ICONHRPortal
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.CreateCustomContext);
          //  app.CreatePerOwinContext(CBSCustomDbContext.CreateCustomContext);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            //  app.UseCookieAuthentication(new CookieAuthenticationOptions());

            //or below code for cookie
           
           app.UseCookieAuthentication(new CookieAuthenticationOptions
           {
               AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
               LoginPath = new PathString("/Login/index"),
               LogoutPath = new PathString("/Account/LogOff"),
               ExpireTimeSpan = TimeSpan.FromMinutes(15.0),
           });

           app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "publicClientId";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/userapi"), // TODO find end points of API
               // AccessTokenExpireTimeSpan = TimeSpan.FromDays(14), // default 
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(5),  
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

        }
    }


    public class ApplicationDbContext
    { 
        public static ICONHRContext CreateCustomContext()
        {
            return new ICONHRContext();
        }
    }
}

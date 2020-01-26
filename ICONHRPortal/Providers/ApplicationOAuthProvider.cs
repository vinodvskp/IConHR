using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using ICONHRPortal.Data.Models;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using ICONHRPortal.Models;
using ICONHRPortal.Data;

namespace ICONHRPortal.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var emailId = AESEncrytDecry.DecryptStringAES(context.UserName);

            var password = AESEncrytDecry.DecryptStringAES(context.Password);
            tblEmployeeDetail userData = null;
            tblEmployeeJobDetail jobDeatils = null;
            var data = context.OwinContext.Get<ICONHRContext>();
            try
            {
                userData = data.EmployeeDetails.FirstOrDefault(x => x.EmailID == emailId);
                jobDeatils = data.EmployeeJobDetails.FirstOrDefault(x => x.EmpID == userData.EmpID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            if (userData == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
          //  bool isMatchPassword = PasswordHash.ValidatePassword(password, "1000:" + Convert.ToString(userData.PasswordSalt) + ":" + Convert.ToString(userData.PasswordHash));

            if (userData.PasswordSalt != context.Password)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
               // return;
            }

            // string imgData = Base64EncodeBytes(userData.ProfilePhoto);
            string profilePhoto=string.Empty;
            if (userData.ProfilePhoto != null)
            {
               profilePhoto = Convert.ToBase64String(userData.ProfilePhoto);
            }

            var companyDetail = data.CompanyDetails.Where(x => x.CompanyID == userData.CompanyID).FirstOrDefault();

            if (userData.CreatedDate.HasValue && userData.CreatedDate.Value.AddDays(30) < DateTime.Now)
            {
                if (companyDetail.IsTrailEnd && !companyDetail.IsPaid)
                {
                    //throw new Exception("Payment Redirection");
                    context.SetError("PaymentRedirection", "Payment Redirection");
                    return;
                }
            }
            else
            {
                if (companyDetail.IsTrailEnd && !companyDetail.IsPaid)
                {
                    context.SetError("PaymentRedirection", "Payment Redirection");
                    return;
                }
            }


            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userData.EmpName));
            claims.Add(new Claim(ClaimTypes.Email, userData.EmailID));
            claims.Add(new Claim("UserId", userData.EmpID.ToString()));
            claims.Add(new Claim("CompanyId", userData.CompanyID.ToString()));
            if (companyDetail.CompanyName != null)
            {
               // claims.Add(new Claim("CompanyName", companyDetail.CompanyName));
            }
            claims.Add(new Claim(ClaimTypes.SerialNumber, userData.EmpID.ToString()));
            //claims.Add(new Claim("ProfilePhoto", userData.ProfilePhoto));
            // claims.Add(userData.ProfilePhoto);
            claims.Add(new Claim(ClaimTypes.Role, "Admin")); // userData.EmpRoleID TODO get roles from db
            if (jobDeatils != null)
            {
                claims.Add(new Claim("RepMgrID", jobDeatils.RepMgrID.ToString()));
               var reportMngDetails = data.EmployeeDetails.FirstOrDefault(x => x.EmpID == jobDeatils.RepMgrID);
                if(reportMngDetails!=null)
                {
                    claims.Add(new Claim("RepMgrName", reportMngDetails.EmpName));
                }
                claims.Add(new Claim("DepartmentId", jobDeatils.DeptID.ToString()));
                claims.Add(new Claim("LocationId", jobDeatils.LocationID.ToString()));
            }
            // Setting Claim Identities for OAUTH 2 protocol.  
            ClaimsIdentity oAuthClaimIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesClaimIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie); // CookieAuthenticationDefaults.AuthenticationType match this in auth.cs(app.UseCookieAuthentication())


            AuthenticationProperties properties = CreateProperties(userData.EmpName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthClaimIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesClaimIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }

    // TODO move this class to file
    public class AESEncrytDecry
    {

        public static string DecryptStringAES(string cipherText)
        {
            var keybytes = Encoding.UTF8.GetBytes("8080808080808080");
            var iv = Encoding.UTF8.GetBytes("8080808080808080");

            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
            return string.Format(decriptedFromJavascript);
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                try
                {
                    // Create the streams used for decryption.
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();

                            }

                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }

            return plaintext;
        }

        private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            byte[] encrypted;
            // Create a RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

    }
}
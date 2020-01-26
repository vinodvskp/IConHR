using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace ICONHRPortal.Extensions
{
    public static class ClaimsExtensions
    {
        public static Claim FindClaim(this IPrincipal user, string claimType)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(claimType)) throw new ArgumentNullException(nameof(claimType));

            var claimsPrincipal = user as ClaimsPrincipal;
            return claimsPrincipal?.FindFirst(claimType);
        }

        public static string GetName(this IPrincipal user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return FindClaim(user, ClaimTypes.Name)?.Value;
        }

        public static string GetRole(this IPrincipal user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return FindClaim(user, ClaimTypes.Role)?.Value;
        }

        public static int? GetUserId(this IPrincipal user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            string value = FindClaim(user, ClaimTypes.SerialNumber)?.Value;
            if (string.IsNullOrEmpty(value)) return default(int?);

            int result;
            return int.TryParse(value, out result) ? result : default(int?);
        }
    }

    public static class IdentityExtension
    {
        public static string GetRole(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Role);
            if (claim != null)
                return claim.Value;

            return string.Empty;
        }

        public static string GetUserById(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst("UserId");
            if(claim != null)
            return claim.Value;

            return string.Empty;
        }
        public static string GetRepMgrID(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst("RepMgrID");
            if (claim != null)
                return claim.Value;

            return string.Empty;
        }

        public static string GetDepartmentId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst("DepartmentId");
            if (claim != null)
                return claim.Value;

            return string.Empty;
        }
        
        public static string GetCompanyId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst("CompanyId");
            if (claim != null)
                return claim.Value;

            return string.Empty;
        }

        public static string GetCompanyName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst("CompanyName");
            if (claim != null)
                return claim.Value;

            return string.Empty;
        }
        
        public static string LocationId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst("LocationId");
            if (claim != null)
                return claim.Value;

            return string.Empty;
        }
    }
}
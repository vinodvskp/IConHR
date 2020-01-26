using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblAdminDetail
    {
        public int AdminID { get; set; }
        public string EmailID { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblDomainDetail
    {
        public int DomainID { get; set; }
        public string DomainName { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public virtual tblCompanyDetail tblCompanyDetail { get; set; }
    }
}

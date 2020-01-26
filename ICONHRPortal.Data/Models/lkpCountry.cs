using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpCountry
    {
        public lkpCountry()
        {
            this.tblCreditCardBillingDetails = new List<tblCreditCardBillingDetail>();
            this.tblEmployeeDetails = new List<tblEmployeeDetail>();
        }

        public int CountryID { get; set; }
        public string CountryCode2 { get; set; }
        public string CountryName { get; set; }
        public string CountryCode3 { get; set; }
        public Nullable<int> Code { get; set; }
        public Nullable<int> PhoneCode { get; set; }
        public virtual ICollection<tblCreditCardBillingDetail> tblCreditCardBillingDetails { get; set; }
        public virtual ICollection<tblEmployeeDetail> tblEmployeeDetails { get; set; }
    }
}

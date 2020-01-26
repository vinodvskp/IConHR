using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblCreditCardBillingDetail
    {
        public int ID { get; set; }
        public Nullable<int> CreditCardID { get; set; }
        public string Name { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string PostalCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public virtual lkpCountry lkpCountry { get; set; }
    }
}

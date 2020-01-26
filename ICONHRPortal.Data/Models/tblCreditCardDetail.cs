using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblCreditCardDetail
    {
        public int CreditCardID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public string CardHolder { get; set; }
        public Nullable<int> CardTypeID { get; set; }
        public string CardNumber { get; set; }
        public Nullable<int> CardExpMonthID { get; set; }
        public Nullable<int> CardExpYearID { get; set; }
        public string GatewayTokenID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public virtual lkpCardExpMonth lkpCardExpMonth { get; set; }
        public virtual lkpCardExpYear lkpCardExpYear { get; set; }
        public virtual lkpCardType lkpCardType { get; set; }
        public virtual tblEmployeeDetail tblEmployeeDetail { get; set; }
    }
}

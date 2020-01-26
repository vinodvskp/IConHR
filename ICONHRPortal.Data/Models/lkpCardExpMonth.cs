using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpCardExpMonth
    {
        public lkpCardExpMonth()
        {
            this.tblCreditCardDetails = new List<tblCreditCardDetail>();
        }

        public int CardExpMonthID { get; set; }
        public Nullable<int> CardExpMonth { get; set; }
        public string CardExpMonthName { get; set; }
        public virtual ICollection<tblCreditCardDetail> tblCreditCardDetails { get; set; }
    }
}

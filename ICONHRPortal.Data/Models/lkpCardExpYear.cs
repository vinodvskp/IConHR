using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpCardExpYear
    {
        public lkpCardExpYear()
        {
            this.tblCreditCardDetails = new List<tblCreditCardDetail>();
        }

        public int CardExpYearID { get; set; }
        public Nullable<int> CardExpYear { get; set; }
        public virtual ICollection<tblCreditCardDetail> tblCreditCardDetails { get; set; }
    }
}

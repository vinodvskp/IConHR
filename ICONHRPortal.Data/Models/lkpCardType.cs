using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpCardType
    {
        public lkpCardType()
        {
            this.tblCreditCardDetails = new List<tblCreditCardDetail>();
        }

        public int CardTypeID { get; set; }
        public string CardType { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual ICollection<tblCreditCardDetail> tblCreditCardDetails { get; set; }
    }
}

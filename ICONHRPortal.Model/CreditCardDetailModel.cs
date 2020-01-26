using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class CreditCardDetailModel
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
    }
}

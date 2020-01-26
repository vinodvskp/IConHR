using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IPaymentService
    {
        int SaveCreditCardDetailModel(CreditCardDetailModel model);
        CountryCardDetailsModel GetCountryCardDetails();
    }
}

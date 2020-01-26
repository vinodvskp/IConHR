using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ICONHRPaymentGateway
{

    public class CustomCart
    {
        public string CURRENT_USER_SHOPPINGCART = "CURRENT_USER_SHOPPINGCART";

        public string Description { get; set; }
        public string BillingSurname { get; set; }
        public string BillingFirstnames { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingCountry { get; set; }
        public string DeliverySurname { get; set; }
        public string DeliveryFirstnames { get; set; }
        public string DeliveryAddress1 { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryCountry { get; set; }
        public string BillingPostCode { get; set; }
        public string DeliveryPostCode { get; set; }
        public string BasketXml { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }

        public void Clean()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session[CURRENT_USER_SHOPPINGCART] != null)
                {
                    HttpContext.Current.Session[CURRENT_USER_SHOPPINGCART] = null;
                    HttpContext.Current.Session[CURRENT_USER_SHOPPINGCART] = new CustomCart();
                }
            }
        }

        public CustomCart Current()
        {
            CustomCart shoppingCart = null;
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session[CURRENT_USER_SHOPPINGCART] == null)
                {
                    shoppingCart = new CustomCart();
                    HttpContext.Current.Session[CURRENT_USER_SHOPPINGCART] = shoppingCart;
                }
                else
                {
                    shoppingCart = (CustomCart)HttpContext.Current.Session[CURRENT_USER_SHOPPINGCART];
                }
            }
            return shoppingCart;
        }
    }

    public class CustomForm
    {
        [Required(ErrorMessage ="Please enter first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter address line 1")]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Please enter address line 2")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        public string City { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter postal code")]
        public string PostCode { get; set; }
        public string ItemList { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Description { get; set; }
        public string getDefaultCountry()
        {
            return "GB";
        }
        public string getDefaultDescription()
        {
            return "Your custom description goes here";
        }
        public string getDefaultItemXML()
        {
            return "<basket><item><description>Sample Item</description><quantity>1</quantity><unitNetAmount>1</unitNetAmount><unitTaxAmount>0</unitTaxAmount><unitGrossAmount>1</unitGrossAmount><totalGrossAmount>1</totalGrossAmount></item></basket>";
        }
    }
}

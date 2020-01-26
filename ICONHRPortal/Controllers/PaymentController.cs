using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using ICONHRPortal.Data;
using ICONHRPortal.Model;
using Newtonsoft.Json;
using System.Configuration;
using ICONHRPaymentGateway;
using SagePay.IntegrationKit;
using SagePay.IntegrationKit.Messages;

namespace ICONHRPortal.Controllers
{

    public class PaymentController : Controller
    {
        // GET: Payment
        #region Variables
        string response = Convert.ToString(ConfigurationManager.AppSettings["response"]);
        ICONHRRepository repository = new ICONHRRepository();
        EmployeeDetails empDetails = new EmployeeDetails();
        CreditCardDetails ccDetails = new CreditCardDetails();
        string responseMsg = string.Empty;
        #endregion

        public ActionResult Index()
        {
            CustomForm customForm = new CustomForm();
            return View(customForm);
            //return View();
        }

        [HttpPost]
        public ActionResult Index(CustomForm model)
        {
            if (ModelState.IsValid)
            {
                CustomForm form = new CustomForm();
                CustomCart cart = new CustomCart();
                cart.Description = model.Description != null ? model.Description : form.getDefaultDescription();
                cart.BillingSurname = model.LastName;
                cart.BillingFirstnames = model.FirstName;
                cart.BillingAddress1 = model.Address1;
                cart.BillingAddress2 = model.Address2;
                cart.BillingCity = model.City;
                cart.BillingCountry = form.getDefaultCountry();
                cart.DeliverySurname = model.LastName;
                cart.DeliveryFirstnames = model.FirstName;
                cart.DeliveryAddress1 = model.Address1;
                cart.DeliveryAddress2 = model.Address2;
                cart.DeliveryCity = model.City;
                cart.DeliveryCountry = form.getDefaultCountry();
                cart.BillingPostCode = model.PostCode;
                cart.DeliveryPostCode = model.PostCode;
                cart.BasketXml = form.getDefaultItemXML();
                cart.Phone = model.Phone;
                cart.DOB = model.DOB.ToShortDateString();
                Session[cart.CURRENT_USER_SHOPPINGCART] = cart;
                return RedirectToAction("Confirm");
            }
            return View(model);
        }


        public ActionResult Confirm()
        {
            //Assign value to form field from session
            CustomCart cart = new CustomCart().Current();
            CustomForm customForm = new CustomForm();
            customForm.FirstName = cart.BillingFirstnames;
            customForm.LastName = cart.BillingSurname;
            customForm.Address1 = cart.BillingAddress1;
            customForm.Address2 = cart.BillingAddress2;
            customForm.City = cart.BillingCity;
            customForm.PostCode = cart.BillingPostCode;
            customForm.Country = cart.BillingCountry;
            customForm.Phone = cart.Phone;
            customForm.DOB = Convert.ToDateTime(cart.DOB);

            SagePayFormIntegration sagePayFormIntegration = new SagePayFormIntegration();

            IFormPayment request = sagePayFormIntegration.FormPaymentRequest();
            SetSagePayAPIData(request);

            var errors = sagePayFormIntegration.Validation(request);

            if (errors == null || errors.Count == 0)
            {
                sagePayFormIntegration.ProcessRequest(request);
                ViewBag.Crypt = request.Crypt;
            }
            else
            {
                ViewBag.Error = "Some error occurred";
            }
            return View(customForm);
        }

        public ActionResult Result(string customParams, string crypt = "")
        {
            try
            {
                IFormPaymentResult PaymentStatusResult;
                SagePayFormIntegration sagePayFormIntegration = new SagePayFormIntegration();
                PaymentStatusResult = sagePayFormIntegration.ProcessResult(crypt);
                ViewBag.StatusResult = PaymentStatusResult;
                DataObject tempObj = ((DataObject)PaymentStatusResult);
                ViewBag._customParams = customParams;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message + "<<<<::::::::::::::::>>>>";
                errorMessage += ex.StackTrace + "<<<<::::::::::::::::>>>>" + ex.Source + "<<<<::::::::::::::::>>>>";
                if (ex.InnerException != null)
                {
                    errorMessage += ex.InnerException.Message;
                }
                ViewBag.Error = errorMessage;
            }
            return View();
        }

        private void SetSagePayAPIData(IFormPayment request)
        {
            var isCollectRecipientDetails = SagePaySettings.IsCollectRecipientDetails;
            CustomCart cart = new CustomCart().Current();

            request.VpsProtocol = SagePaySettings.ProtocolVersion;
            request.TransactionType = SagePaySettings.DefaultTransactionType;
            request.Vendor = SagePaySettings.VendorName;
            request.VendorTxCode = SagePayFormIntegration.GetNewVendorTxCode();

            request.Amount = 1; //Custom value set
            request.Currency = SagePaySettings.Currency;
            request.SuccessUrl = SagePaySettings.SiteFqdn + "Payment/Result?customParams=Transaction Details For Success";
            request.FailureUrl = SagePaySettings.SiteFqdn + "Payment/Result?customParams=Transaction Details For Failure";
            request.Description = cart.Description;
            request.BillingSurname = cart.BillingSurname;
            request.BillingFirstnames = cart.BillingFirstnames;
            request.BillingAddress1 = cart.BillingAddress1 + " " + cart.BillingAddress2;
            request.BillingCity = cart.BillingCity;
            request.BillingCountry = cart.BillingCountry;

            request.DeliverySurname = cart.DeliverySurname;
            request.DeliveryFirstnames = cart.DeliveryFirstnames;
            request.DeliveryAddress1 = cart.DeliveryAddress1 + " " + cart.DeliveryAddress2;
            request.DeliveryCity = cart.DeliveryCity;
            request.DeliveryCountry = cart.DeliveryCountry;

            //Optional
            request.BillingPostCode = cart.BillingPostCode;
            request.DeliveryPostCode = cart.DeliveryPostCode;
            request.BasketXml = cart.BasketXml;

            request.VendorEmail = SagePaySettings.VendorEmail;
            request.SendEmail = SagePaySettings.SendEmail;
            request.EmailMessage = SagePaySettings.EmailMessage;

            request.AllowGiftAid = SagePaySettings.AllowGiftAid;
            request.ApplyAvsCv2 = SagePaySettings.ApplyAvsCv2;
            request.Apply3dSecure = SagePaySettings.Apply3dSecure;
            request.BillingAgreement = "";
            request.ReferrerId = SagePaySettings.ReferrerID;
            request.SurchargeXml = SagePaySettings.SurchargeXML;
            //set vendor data
            request.VendorData = "";
        }


        #region To save credit card and billing details
        [HttpPost]
        public string CreditCardAndBillingDetails(string cardHolderName, int cardType, string cardNumber, int CVV, int cardExpMonth, int cardExpYear,
                                                  string Name, string address, int country, string postalCode, string phoneNumber, string email)
        {
            empDetails = new EmployeeDetails();
            ccDetails = new CreditCardDetails();
            repository = new ICONHRRepository();
            responseMsg = string.Empty;
            int empId = 0;

            try
            {
                //Employee details
                empDetails = (EmployeeDetails)Session["EmployeeModel"];
                empDetails.Country_ID = Convert.ToInt32(country);
                responseMsg = repository.AddNewEmpDetails(empDetails);

                string[] arrResponse = responseMsg.Split(',');
                if (response.Length > 1)
                {
                    responseMsg = Convert.ToString(arrResponse[0]);
                    empId = Convert.ToInt32(arrResponse[1]);
                    if (empId != 0)
                    {
                        // Card Card details
                        repository = new ICONHRRepository();
                        ccDetails.Emp_ID = empId;
                        ccDetails.CardHolder = cardHolderName;
                        ccDetails.CardTypeID = cardType;
                        ccDetails.CardNumber = cardNumber;
                        ccDetails.CVV = CVV;
                        ccDetails.Card_Exp_Month_ID = cardExpMonth;
                        ccDetails.Card_Exp_Year_ID = cardExpYear;

                        // Billing details
                        ccDetails.Name = Name;
                        ccDetails.Address = address;
                        ccDetails.Country_ID = country;
                        ccDetails.PostalCode = postalCode;
                        ccDetails.BillingEmail = email;
                        ccDetails.BillingPhoneNumber = phoneNumber;
                        ccDetails.Created_By = empDetails.Created_By;

                        responseMsg = repository.AddCreditCardDetails(ccDetails);

                        if (responseMsg == response)
                        {
                            Session["EmployeeModel"] = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                var frame = trace.FrameCount > 1 ? trace.GetFrame(1) : trace.GetFrame(0);
                int Line = (int)frame.GetFileLineNumber();
                string methodName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                LogClass.CreateLogXml(ex.Message, controllerName, Convert.ToString(ex.InnerException), methodName, Line);
            }

            return responseMsg;
        }
        #endregion

        #region To get credit card expire and countries details
        [HttpGet]
        public string GetCountryAndCardDetails()
        {
            repository = new ICONHRRepository();
            DataSet ds_CountryAndCardDetails = new DataSet();
            string data = string.Empty;

            try
            {
                ds_CountryAndCardDetails = repository.GetCountryAndCardDetails();
                data = JsonConvert.SerializeObject(ds_CountryAndCardDetails);
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                var frame = trace.FrameCount > 1 ? trace.GetFrame(1) : trace.GetFrame(0);
                int Line = (int)frame.GetFileLineNumber();
                string methodName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                LogClass.CreateLogXml(ex.Message, controllerName, Convert.ToString(ex.InnerException), methodName, Line);
            }

            return data;
        }
        #endregion
    }
}
using System;
using System.Collections.Specialized;
using System.Text;
using SagePay.IntegrationKit;
using SagePay.IntegrationKit.Messages;
using System.Reflection;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for FormIntegration
/// </summary>
public class SagePayFormIntegration : SagePayAPIIntegration
{
    public IFormPayment FormPaymentRequest()
    {
        IFormPayment request = new DataObject();
        return request;
    }

    public NameValueCollection Validation(IFormPayment formPayment)
    {
        if(SagePaySettings.EnableClientValidation)
            return Validation(ProtocolMessage.FORM_PAYMENT, typeof(IFormPayment), formPayment, SagePaySettings.ProtocolVersion);
        return null;
    }

    public IFormPayment ProcessRequest(IFormPayment formPayment)
    {
        RequestQueryString = BuildQueryString(ConvertSagePayMessageToNameValueCollection(ProtocolMessage.FORM_PAYMENT, typeof(IFormPayment), formPayment,SagePaySettings.ProtocolVersion));

        formPayment.Crypt = Cryptography.EncryptAndEncode(RequestQueryString, SagePaySettings.EncryptionPassword);

        return formPayment;
    }

    public IFormPaymentResult ProcessResult(string crypt)
    {
        IFormPaymentResult formPaymentResult = new DataObject();

        string cryptDecoded = Cryptography.DecodeAndDecrypt(crypt, SagePaySettings.EncryptionPassword);

        formPaymentResult = (IFormPaymentResult)ConvertToSagePayMessage(cryptDecoded);

        return formPaymentResult;
    }
}
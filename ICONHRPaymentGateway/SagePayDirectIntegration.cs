using System;
using System.Collections.Specialized;
using System.Text;
using SagePay.IntegrationKit;
using SagePay.IntegrationKit.Messages;
using System.Reflection;
using System.Web;
using System.IO;
using System.Net;

/// <summary>
/// Summary description for FormIntegration
/// </summary>
public class SagePayDirectIntegration : SagePayAPIIntegration
{
    public IDirectPaymentResult ProcessDirect3D(IThreeDAuthRequest request)
    {
        //request.TransactionType = TransactionType.three;
        RequestQueryString = BuildQueryString(request, ProtocolMessage.THREE_D_AUTH_REQUEST, SagePaySettings.ProtocolVersion);
        ResponseQueryString = ProcessWebRequestToSagePay(SagePaySettings.Direct3dSecureUrl, RequestQueryString);
        IDirectPaymentResult result = GetDirectPaymentResult(ResponseQueryString);
        return result;
    }


    public IThreeDAuthRequest ThreeDAuthRequest()
    {
        IThreeDAuthRequest request = new DataObject();
        return request;
    }

 

}
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
public class SagePayAdminIntegration : SagePayAPIIntegration
{
    public IVoidRequest VoidRequest()
    {
        IVoidRequest request = new DataObject();
        return request;
    }

    public ICancelRequest CancelRequest()
    {
        ICancelRequest request = new DataObject();
        return request;
    }

    public IAbortRequest AbortRequest()
    {
        IAbortRequest request = new DataObject();
        return request;
    }

    public IAuthoriseRequest AuthoriseRequest()
    {
        IAuthoriseRequest request = new DataObject();
        return request;
    }

    public IRefundRequest RefundRequest()
    {
        IRefundRequest request = new DataObject();
        return request;
    }

    public IReleaseRequest ReleaseRequest()
    {
        IReleaseRequest request = new DataObject();
        return request;
    }
    public IRepeatRequest RepeatRequest()
    {
        IRepeatRequest request = new DataObject();
        return request;
    }

    public IBasicResult DoVoid(IVoidRequest request)
    {
        request.TransactionType = TransactionType.VOID;
        RequestQueryString = BuildQueryString(request, ProtocolMessage.VOID_REQUEST, SagePaySettings.ProtocolVersion);
		ResponseQueryString = ProcessWebRequestToSagePay(SagePaySettings.VoidUrl, RequestQueryString);
        IBasicResult result = ConvertToBasicResult(ResponseQueryString);
        return result;
    }

    public IBasicResult DoCancel(ICancelRequest request)
    {
        request.TransactionType = TransactionType.CANCEL;
        RequestQueryString = BuildQueryString(request, ProtocolMessage.CANCEL_REQUEST, SagePaySettings.ProtocolVersion);
		ResponseQueryString = ProcessWebRequestToSagePay(SagePaySettings.CancelUrl, RequestQueryString);
        IBasicResult result = ConvertToBasicResult(ResponseQueryString);
        return result;
    }

    public IBasicResult DoAbort(IAbortRequest request)
    {
        request.TransactionType = TransactionType.ABORT;
        RequestQueryString = BuildQueryString(request, ProtocolMessage.ABORT_REQUEST, SagePaySettings.ProtocolVersion);
		ResponseQueryString = ProcessWebRequestToSagePay(SagePaySettings.AbortUrl, RequestQueryString);
        IBasicResult result = ConvertToBasicResult(ResponseQueryString);
        return result;
    }

    public ICaptureResult DoAuthorise(IAuthoriseRequest request)
    {
        request.TransactionType = TransactionType.AUTHORISE;
        RequestQueryString = BuildQueryString(request, ProtocolMessage.AUTHORISE_REQUEST, SagePaySettings.ProtocolVersion);
		ResponseQueryString = ProcessWebRequestToSagePay(SagePaySettings.AuthoriseUrl, RequestQueryString);
        ICaptureResult result = ConvertToCaptureResult(ResponseQueryString);
        return result;
    }

    public IRefundResult DoRefund(IRefundRequest request)
    {
        request.TransactionType = TransactionType.REFUND;
        RequestQueryString = BuildQueryString(request, ProtocolMessage.REFUND_REQUEST, SagePaySettings.ProtocolVersion);
		ResponseQueryString = ProcessWebRequestToSagePay(SagePaySettings.RefundUrl, RequestQueryString);
        IRefundResult result = ConvertToRefundResult(ResponseQueryString);
        return result;
    }

    public IBasicResult DoRelease(IReleaseRequest request)
    {
        request.TransactionType = TransactionType.RELEASE;
        RequestQueryString = BuildQueryString(request, ProtocolMessage.RELEASE_REQUEST, SagePaySettings.ProtocolVersion);
		ResponseQueryString = ProcessWebRequestToSagePay(SagePaySettings.ReleaseUrl, RequestQueryString);
        IBasicResult result = ConvertToBasicResult(ResponseQueryString);
        return result;
    }

    public ICaptureResult DoRepeat(IRepeatRequest request, bool deferred)
    {
        if (deferred)
            request.TransactionType = TransactionType.REPEATDEFERRED;
        else
            request.TransactionType = TransactionType.REPEAT;

        RequestQueryString = BuildQueryString(request, ProtocolMessage.REPEAT_REQUEST, SagePaySettings.ProtocolVersion);
		ResponseQueryString = ProcessWebRequestToSagePay(SagePaySettings.RepeatUrl, RequestQueryString);
        ICaptureResult result = ConvertToCaptureResult(ResponseQueryString);
        return result;
    }

}
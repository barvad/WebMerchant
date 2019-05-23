using System.Collections.Generic;
using WebMerchant.InternetAcquiring.Enums;

namespace WebMerchant.InternetAcquiring.Contracts.Payment
{
    public interface IResponseParserFactory
    {
        IResponseParser GetParser(Dictionary<string, object> paymentResponseData, AcquiringType acquiringType);
    }
}
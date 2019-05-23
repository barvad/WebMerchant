using System.Collections.Generic;
using WebMerchant.InternetAcquiring.Enums;
using WebMerchant.InternetAcquiring.Objects.Payments;

namespace WebMerchant.InternetAcquiring.Contracts.Bl
{
    public interface IResponseProcessor
    {
        ResponseProcessingResult ProcessResponse(Dictionary<string, object> paymentResponseData,
                                                 AcquiringType acquiringType);
    }
}
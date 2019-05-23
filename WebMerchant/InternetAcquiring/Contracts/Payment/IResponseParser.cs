using System.Collections.Generic;
using WebMerchant.InternetAcquiring.Objects.Payments;

namespace WebMerchant.InternetAcquiring.Contracts.Payment
{
    public interface IResponseParser
    {
        PaymentResponse Parse(Dictionary<string, object> paymentResponseData);
    }
}
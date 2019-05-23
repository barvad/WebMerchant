using WebMerchant.InternetAcquiring.Objects.Payments;

namespace WebMerchant.InternetAcquiring.Contracts.Bl
{
    public interface IRequestGetter
    {
        object GetRequest(PaymentData paymentData, out string requestUrl);
    }
}
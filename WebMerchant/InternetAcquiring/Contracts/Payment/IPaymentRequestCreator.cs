using WebMerchant.InternetAcquiring.Enums;

namespace WebMerchant.InternetAcquiring.Contracts.Payment
{
    public interface IPaymentRequestCreator
    {
        AcquiringType Type { get; }
        object GetRequest();
        string GetPaymentUrl();
    }
}
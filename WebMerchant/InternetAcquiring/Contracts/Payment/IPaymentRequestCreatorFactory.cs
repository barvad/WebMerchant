using WebMerchant.InternetAcquiring.Objects.Payments;

namespace WebMerchant.InternetAcquiring.Contracts.Payment
{
    public interface IPaymentRequestCreatorFactory
    {
        IPaymentRequestCreator GetRequestCreator(PaymentData paymentData);
    }
}
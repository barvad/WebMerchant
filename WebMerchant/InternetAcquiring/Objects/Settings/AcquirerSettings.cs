using WebMerchant.InternetAcquiring.Enums;

namespace WebMerchant.InternetAcquiring.Objects.Settings
{
    public class AcquirerSettings
    {
        public AcquiringType AcquiringType { get; set; }
        public string MerchantId { get; set; }
        public string PaymentUrl { get; set; }
        public string SecretKey { get; set; }
    }
}
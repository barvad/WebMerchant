using WebMerchant.InternetAcquiring.Enums;

namespace WebMerchant.InternetAcquiring.Objects.Payments
{
    public class PaymentData
    {
        public string InvoiceNumber { get; set; }
        public decimal? Sum { get; set; }
        public decimal? LogisticSum { get; set; }
        public double? AgentFee { get; set; }
        public string Language { get; set; }
        public string TransactionNumber { get; set; }
        public string PointNumber { get; set; }
        public string BackUrl { get; set; }
        public AcquiringType Acquirer { get; set; }
        public bool IsTest { get; set; }
    }
}
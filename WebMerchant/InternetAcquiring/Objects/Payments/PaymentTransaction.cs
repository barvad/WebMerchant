using WebMerchant.InternetAcquiring.Enums;

namespace WebMerchant.InternetAcquiring.Objects.Payments
{
    public class PaymentTransaction
    {
        public string TransactionNumber { get; set; }
        public decimal? LogisticSum { get; set; }
        public decimal? InvoiceSum { get; set; }
        public PaymentTransactionState State { get; set; }
        public string InvoiceNumber { get; set; }
        public double? AgentFee { get; set; }
        public string PointNumber { get; set; }
        public AcquiringType Acquirier { get; set; }
    }
}
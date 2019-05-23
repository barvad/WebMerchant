namespace WebMerchant.InternetAcquiring.Objects.Payments
{
    public class PaymentResponse
    {
        public string TransactionNumber { get; set; }
        public bool IsComplete { get; set; }
        public bool IsAuthorized { get; set; }
        public string Message { get; set; }
        public ResponseProcessingResult Result { get; set; }
    }
}
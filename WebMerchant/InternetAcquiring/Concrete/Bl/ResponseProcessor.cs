using System.Collections.Generic;
using WebMerchant.InternetAcquiring.Contracts.Bl;
using WebMerchant.InternetAcquiring.Contracts.Data;
using WebMerchant.InternetAcquiring.Contracts.Payment;
using WebMerchant.InternetAcquiring.Enums;
using WebMerchant.InternetAcquiring.Objects.Payments;

namespace WebMerchant.InternetAcquiring.Concrete.Bl
{
    public class ResponseProcessor : IResponseProcessor
    {
        private readonly IResponseParserFactory _responseParserFactory;
        private readonly IRepository<PaymentTransaction> _transactionRepository;

        public ResponseProcessor(IResponseParserFactory responseParserFactory,
                                 IRepository<PaymentTransaction> transactionRepository)
        {
            this._responseParserFactory = responseParserFactory;
            this._transactionRepository = transactionRepository;
        }

        public ResponseProcessingResult ProcessResponse(Dictionary<string, object> paymentResponseData,
                                                        AcquiringType acquiringType)
        {
            var parser = _responseParserFactory.GetParser(paymentResponseData, acquiringType);
            var response = parser.Parse(paymentResponseData);
            var transaction = _transactionRepository.Get(response.TransactionNumber);
            if (response.IsComplete)
            {
                transaction.State = PaymentTransactionState.Complete;
                _transactionRepository.Update(transaction);
            }
            return response.Result;
        }
    }
}
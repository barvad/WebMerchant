using System;
using WebMerchant.InternetAcquiring.Contracts.Bl;
using WebMerchant.InternetAcquiring.Contracts.Data;
using WebMerchant.InternetAcquiring.Contracts.Payment;
using WebMerchant.InternetAcquiring.Enums;
using WebMerchant.InternetAcquiring.Objects.Payments;

namespace WebMerchant.InternetAcquiring.Concrete.Bl
{
    public class RequestGetter : IRequestGetter
    {
        private readonly IPaymentRequestCreatorFactory _requestCreatorFactory;
        private readonly IRepository<PaymentTransaction> _transactionsRepository;

        public RequestGetter(IPaymentRequestCreatorFactory requestCreatorFactory,
                             IRepository<PaymentTransaction> transactionsRepository)
        {
            this._requestCreatorFactory = requestCreatorFactory;
            this._transactionsRepository = transactionsRepository;
        }

        public object GetRequest(PaymentData paymentData, out string requestUrl)
        {
            var requestCreator = _requestCreatorFactory.GetRequestCreator(paymentData);
            paymentData.Acquirer = requestCreator.Type;
            var transaction = CreateNewTransaction(paymentData);
            paymentData.TransactionNumber = transaction.TransactionNumber;
            requestUrl = requestCreator.GetPaymentUrl();
            var req = requestCreator.GetRequest();
            return req;
        }


        private PaymentTransaction CreateNewTransaction(PaymentData paymentData)
        {
            var transaction = new PaymentTransaction
                              {
                                  TransactionNumber = $"{Guid.NewGuid():N}",
                                  InvoiceSum = paymentData.Sum,
                                  LogisticSum = paymentData.LogisticSum,
                                  AgentFee = paymentData.AgentFee,
                                  State = PaymentTransactionState.New,
                                  InvoiceNumber = paymentData.InvoiceNumber,
                                  PointNumber = paymentData.PointNumber,
                                  Acquirier = paymentData.Acquirer
                              };
            _transactionsRepository.Create(transaction);
            return transaction;
        }
    }
}
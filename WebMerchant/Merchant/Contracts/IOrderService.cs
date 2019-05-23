using System;
using WebMerchant.Merchant.Objects;

namespace WebMerchant.Merchant.Contracts
{
    public interface IOrderService
    {
        void StartPurchaseOrder(Order order);
        Order GetOrder(Guid orderId);
    }
}
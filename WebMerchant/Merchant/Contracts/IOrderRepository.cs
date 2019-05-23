using System;
using WebMerchant.InternetAcquiring.Enums.Repositories;
using WebMerchant.Merchant.Objects;

namespace WebMerchant.Merchant.Contracts
{
    public interface IOrderRepository
    {
        AddResult AddOrder(Order order);
        Order GetOrder(Guid orderId);
    }
}
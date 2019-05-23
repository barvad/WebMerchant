using System;
using System.Transactions;
using WebMerchant.Merchant.Contracts;
using WebMerchant.Merchant.Objects;

namespace WebMerchant.Merchant.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IGoodsRepository _goodsRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IGoodsRepository goodsRepository, IOrderRepository orderRepository)
        {
            _goodsRepository = goodsRepository;
            _orderRepository = orderRepository;
        }

        public void StartPurchaseOrder(Order order)
        {
            using (var transactionScope = new TransactionScope())
            {
                foreach (var orderLine in order.OrderLines)
                    _goodsRepository.ChangeStorageCount(orderLine.Good, -1 * orderLine.Count);
                order.State = OrderState.PurchaseStarted;
                _orderRepository.AddOrder(order);
                transactionScope.Complete();
            }
        }

        public Order GetOrder(Guid orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }
    }
}
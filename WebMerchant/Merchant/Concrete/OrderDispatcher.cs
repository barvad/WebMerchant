using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebMerchant.Merchant.Objects;

namespace WebMerchant.Merchant.Concrete
{
    public class OrderDispatcher
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);
        private readonly List<WeakReference<Order>> _orders = new List<WeakReference<Order>>();
        private object _syncOrders = new object();
        private OrderDispatcher() { }
        public static OrderDispatcher Instance { get; } = new OrderDispatcher();

        public async Task Watch(Order order)
        {
            await _semaphoreSlim.WaitAsync();
            _orders.Add(new WeakReference<Order>(order));
            _semaphoreSlim.Release();
        }
    }
}
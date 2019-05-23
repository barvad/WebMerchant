using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;
using WebMerchant.InternetAcquiring.Enums.Repositories;
using WebMerchant.Merchant.Contracts;
using WebMerchant.Merchant.Objects;

namespace WebMerchant.FakeRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private static readonly object OrdersSync = new object();
        public static List<Order> Orders { get; } = new List<Order>();

        public AddResult AddOrder(Order order)
        {
            var result = AddResult.Ok;
            Exception exception = null;
            try
            {
                Monitor.Enter(string.Intern($"orders_{order.Id}"));
                lock (OrdersSync)
                {
                    if (Orders.Any(x => x.Id == order.Id))
                    {
                        result |= AddResult.AlreadyExists;
                        throw new Exception($"Order Id = {order.Id} already exists");
                    }

                    Orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                Monitor.Exit(string.Intern($"orders_{order.Id}"));
                result |= AddResult.UnknownError;
                exception = ex;
            }


            Action prepare = () =>
                             {
                                 if (result != AddResult.Ok)
                                     throw exception ?? new Exception("Unknown exception");
                             };
            Action commit = () => Monitor.Exit(string.Intern($"orders_{order.Id}"));
            ;
            Action rollBack = () =>
                              {
                                  Orders.Remove(order);
                                  Monitor.Exit(string.Intern($"orders_{order.Id}"));
                              };
            var tran = Transaction.Current;
            if (tran != null)
            {
                var enlistmentNotification = new EnlistmentNotification(tran, prepare, commit, rollBack);
                return result;
            }

            prepare();
            commit();
            return result;
        }

        public Order GetOrder(Guid orderId)
        {
            lock (OrdersSync)
            {
                return Orders.FirstOrDefault(o => o.Id == orderId);
            }
        }
    }
}
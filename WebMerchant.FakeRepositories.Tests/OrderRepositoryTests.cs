using System;
using System.Transactions;
using NUnit.Framework;
using WebMerchant;
using WebMerchant.FakeRepositories;
using WebMerchant.Merchant.Objects;

namespace Tests
{
    public class OrderRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            OrderRepository.Orders.Clear();
        }

        [Test]
        public void OrderRepository_AddDouble_CountEq1()
        {
            var repos = new OrderRepository();
            var order1 = new Order {Id = Guid.NewGuid()};
            var order2 = new Order {Id = Guid.NewGuid()};
            repos.AddOrder(order1);

            try
            {
                using (var ts = new TransactionScope())
                {
                    var res1 = repos.AddOrder(order2);
                    var res2 = repos.AddOrder(order1); //добавление заказа повторно вызывает ошибку
                    ts.Complete();
                }
            }
            catch
            {
                // ignored
            }

            Assert.AreEqual(1, OrderRepository.Orders.Count);
        }

        [Test]
        public void OrderRepository_AddTwoOrders_CountEq2()
        {
            var repos = new OrderRepository();
            var order1 = new Order {Id = Guid.NewGuid()};
            var order2 = new Order {Id = Guid.NewGuid()};


            using (var ts = new TransactionScope())
            {
                repos.AddOrder(order2);
                repos.AddOrder(order1);
                ts.Complete();
            }


            Assert.AreEqual(2, OrderRepository.Orders.Count);
        }
    }
}
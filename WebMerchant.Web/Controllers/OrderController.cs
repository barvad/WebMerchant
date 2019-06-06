using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebMerchant.Merchant.Contracts;
using WebMerchant.Merchant.Objects;
using WebMerchant.Web.Objects;

namespace WebMerchant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("[action]")]
        public object Purchase([FromBody] IEnumerable<CartLine> cartLines)
        {
            var order = new Order
                        {
                            Id = Guid.NewGuid(),
                            OrderLines = cartLines.Select(c => c as OrderLine).ToList()
                        };
            _orderService.StartPurchaseOrder(order);
            return new {Result = 0, Message = "OK", OrderId = order.Id};
        }

        [HttpPost("[action]")]
        public Order GetOrder([FromBody] Order order)
        {
            order = _orderService.GetOrder(order.Id);
            return order;
        }
    }
}
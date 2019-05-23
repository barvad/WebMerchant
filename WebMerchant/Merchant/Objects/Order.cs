using System;
using System.Collections.Generic;

namespace WebMerchant.Merchant.Objects
{
    public class Order
    {
        public Guid Id { get; set; } 
        public IList<OrderLine> OrderLines { get; set; }
        public OrderState State { get; set; }
    }
}

using System;

namespace WebMerchant.Merchant.Objects
{
    public class Good
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int StorageCount { get; set; }
    }
}
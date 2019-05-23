using System;
using System.Collections.Generic;
using WebMerchant.Merchant.Objects;

namespace WebMerchant.Merchant.Contracts
{
    public interface IGoodsRepository
    {
        Good GetGood(Guid id);
        IEnumerable<Good> GetGoods(int skip, int takeCount,ref int count);
        void ChangeStorageCount(Good good,int delta);
    }
}
using System.Collections.Generic;
using WebMerchant.Merchant.Objects;

namespace WebMerchant.Merchant.Contracts
{
    public interface IGoodsService
    {
        IEnumerable<Good> GetGoods(int page, int perPage, ref int count);
    }
}
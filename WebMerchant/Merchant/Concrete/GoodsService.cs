using System.Collections.Generic;
using WebMerchant.Merchant.Contracts;
using WebMerchant.Merchant.Objects;

namespace WebMerchant.Merchant.Concrete {
    public class GoodsService : IGoodsService
    {
        private readonly IGoodsRepository _goodsRepository;

        public GoodsService(IGoodsRepository goodsRepository)
        {
            _goodsRepository = goodsRepository;
        }

        public IEnumerable<Good> GetGoods(int page, int perPage, ref int count)
        {
            return _goodsRepository.GetGoods((page - 1) * perPage, perPage, ref count);
        }
    }
}
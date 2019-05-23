using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;
using WebMerchant.Merchant.Contracts;
using WebMerchant.Merchant.Objects;

namespace WebMerchant.FakeRepositories
{
    public class GoodsRepository : IGoodsRepository
    {
        private static readonly List<Good> _goods = new List<Good>
                                                    {
                                                        new Good
                                                        {
                                                            Id = Guid.Parse("{CD82508D-D858-4956-B103-AD8232A33FE4}"),
                                                            Description = "Ручка шариковая", StorageCount = 20
                                                        },
                                                        new Good
                                                        {
                                                            Id = Guid.Parse("{F8E25A54-DF3A-4998-AA0D-191AFCA4838D}"),
                                                            Description = "Ручка шариковая (красная)", StorageCount = 20
                                                        },
                                                        new Good
                                                        {
                                                            Id = Guid.Parse("{4246C561-842E-4592-B2D2-27980E127080}"),
                                                            Description = "Ручка геливая",
                                                            StorageCount = 20
                                                        },
                                                        new Good
                                                        {
                                                            Id = Guid.Parse("{B51846C3-5BCD-459F-B7BF-5627E8763FB8}"),
                                                            Description = "Степлер",
                                                            StorageCount = 20
                                                        },
                                                        new Good
                                                        {
                                                            Id = Guid.Parse("{F2C96438-4631-45DF-A485-26B1FEC563AA}"),
                                                            Description = "Линейка",
                                                            StorageCount = 20
                                                        },
                                                        new Good
                                                        {
                                                            Id = Guid.Parse("{F02727FC-DDBE-42AE-B0BE-B05FE6B6E65D}"),
                                                            Description = "Тетрадь общая (96 листов)", StorageCount = 20
                                                        }
                                                        ,
                                                        new Good
                                                        {
                                                            Id = Guid.Parse("{568CC1CF-7A82-440B-BB63-EDBB0B2C37C3}"),
                                                            Description = "Тетрадь (20 листов)", StorageCount = 20
                                                        }
                                                    };

        private static readonly object _goodsSync = new object();

        public Good GetGood(Guid id)
        {
            lock (_goodsSync)
            {
                return _goods.FirstOrDefault(g => g.Id == id);
            }
        }

        public IEnumerable<Good> GetGoods(int skip, int takeCount,ref int count)
        {
            lock (_goodsSync)
            {
                count = _goods.Count;
                return _goods.Skip(skip).Take(takeCount).ToList();
            }
        }

        public void ChangeStorageCount(Good good, int delta)
        {

            Good changingGood = null;
            Action prepare = () =>
                             {
                                 try
                                 {
                                     Monitor.Enter(string.Intern($"goods_{good.Id}"));
                                     lock (_goodsSync)
                                     {
                                         changingGood = _goods.First(g => g.Id == good.Id);
                                         var newVal = good.StorageCount + delta ;
                                         if (newVal < 0)
                                             throw new Exception("Storage takeCount new value can't be less then 0");
                                         changingGood.StorageCount = newVal;
                                     }
                                 }
                                 catch
                                 {
                                     Monitor.Exit(string.Intern($"goods_{good.Id}"));
                                     throw;
                                 }
                             };
            Action commit = () =>
                            {
                                Monitor.Exit(string.Intern($"goods_{good.Id}"));
                            };
            Action rollBack = () =>
                              {
                                  if (changingGood != null)
                                      changingGood.StorageCount -=  delta;
                                  Monitor.Exit(string.Intern($"goods_{good.Id}"));
                              };
            var tran = Transaction.Current;
            if (tran != null)
            {
                var enlistmentNotification = new EnlistmentNotification(tran, prepare, commit, rollBack);
            }
            else
            {
                prepare();
                commit();
            }
        }
    }
}
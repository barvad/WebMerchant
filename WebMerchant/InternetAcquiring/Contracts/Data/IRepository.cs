using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebMerchant.InternetAcquiring.Contracts.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
        T Get(string id);
        void Create(T transaction);
        void Update(T item);
        void Delete(string id);
    }
}
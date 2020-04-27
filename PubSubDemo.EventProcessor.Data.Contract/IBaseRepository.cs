using PubSubDemo.EventProcessor.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PubSubDemo.EventProcessor.Data.Contract
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task Add(T entity);

        Task AddRange(IEnumerable<T> entities);

        Task Update(T entity);

        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();

        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}

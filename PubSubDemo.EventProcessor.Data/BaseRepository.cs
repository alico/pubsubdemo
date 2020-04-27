using Microsoft.EntityFrameworkCore;
using PubSubDemo.EventProcessor.Data.Contract;
using PubSubDemo.EventProcessor.Data.Entity;
using PubSubDemo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PubSubDemo.EventProcessor.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ConnectionStrings _connectionStrings;

        public BaseRepository(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public async Task<T> GetById(int id)
        {
            using (new TransactionScope(
                                      TransactionScopeOption.Required,
                                      new TransactionOptions
                                      {
                                          IsolationLevel = IsolationLevel.ReadUncommitted,
                                      }, TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var context = new DataContext(_connectionStrings))
                {
                    return await context.Set<T>().FindAsync(id);
                }
            }
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            using (new TransactionScope(
                                      TransactionScopeOption.Required,
                                      new TransactionOptions
                                      {
                                          IsolationLevel = IsolationLevel.ReadUncommitted,
                                      }, TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var context = new DataContext(_connectionStrings))
                {
                    return context.Set<T>().FirstOrDefaultAsync(predicate);
                }
            }

        }

        public async Task Add(T entity)
        {
            using (var context = new DataContext(_connectionStrings))
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            using (var context = new DataContext(_connectionStrings))
            {
                await context.Set<T>().AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(T entity)
        {
            using (var context = new DataContext(_connectionStrings))
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public Task Remove(T entity)
        {
            using (var context = new DataContext(_connectionStrings))
            {
                context.Set<T>().Remove(entity);
                return context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (new TransactionScope(
                                      TransactionScopeOption.Required,
                                      new TransactionOptions
                                      {
                                          IsolationLevel = IsolationLevel.ReadUncommitted,
                                      }, TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var context = new DataContext(_connectionStrings))
                {
                    return await context.Set<T>().ToListAsync();
                }
            }

        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            using (new TransactionScope(
                                      TransactionScopeOption.Required,
                                      new TransactionOptions
                                      {
                                          IsolationLevel = IsolationLevel.ReadUncommitted,
                                      }, TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var context = new DataContext(_connectionStrings))
                {
                    return await context.Set<T>().Where(predicate).ToListAsync();
                }
            }
        }

        public Task<int> CountAll()
        {
            using (new TransactionScope(
                                      TransactionScopeOption.Required,
                                      new TransactionOptions
                                      {
                                          IsolationLevel = IsolationLevel.ReadUncommitted,
                                      }, TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var context = new DataContext(_connectionStrings))
                {
                    return context.Set<T>().CountAsync();
                }
            }
        }

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            using (new TransactionScope(
                                      TransactionScopeOption.Required,
                                      new TransactionOptions
                                      {
                                          IsolationLevel = IsolationLevel.ReadUncommitted,
                                      }, TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var context = new DataContext(_connectionStrings))
                {
                    return context.Set<T>().CountAsync(predicate);
                }
            }
        }

    }
}

using HumanGuide.Core.Domain.Basics;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> CreateAsync(TEntity entity);

        Task<TEntity> ReadAsync(uint id);
        Task<IEnumerable<TEntity>> ReadAsync();
        Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateAsync(uint id, TEntity entity);

        Task<int> DeleteAsync(uint id);
        Task<int> DeleteAsync(TEntity entity);

        Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}

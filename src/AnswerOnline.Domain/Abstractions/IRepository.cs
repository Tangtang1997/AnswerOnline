using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AnswerOnline.Domain.Abstractions
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; } 
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IList<TEntity>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<IList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        IList<TEntity> List(Expression<Func<TEntity, bool>> predicate); 
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
} 
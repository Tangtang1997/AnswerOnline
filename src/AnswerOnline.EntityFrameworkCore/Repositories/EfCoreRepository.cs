using AnswerOnline.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;

namespace AnswerOnline.EntityFrameworkCore.Repositories
{
    public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        private readonly AppDbContext _dbContext;

        public EfCoreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public IUnitOfWork UnitOfWork => _dbContext;

        public virtual IQueryable<TEntity> GetAll()
        {
            return Table.AsQueryable();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await Table.FindAsync(keyValues, cancellationToken);
        }

        public virtual async Task<IList<TEntity>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Table.ToListAsync(cancellationToken);
        }

        public virtual async Task<IList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Table.AsQueryable().Where(predicate).ToListAsync(cancellationToken);
        }

        public virtual IList<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Table.AddAsync(entity, cancellationToken);

            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Table.AsQueryable().CountAsync(predicate, cancellationToken);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Table.AsQueryable().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        protected virtual void AttachIfNot(TEntity entity)
        { 
            var entry = _dbContext.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            Table.Attach(entity);
        }
    }
}
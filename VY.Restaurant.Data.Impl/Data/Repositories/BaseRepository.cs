using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Data.Contracts.Data.Repositories;

namespace VY.Restaurant.Data.Impl.Data.Repositories
{
    public class BaseRepository<TContext, TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
                                                                                      where TContext : DbContext
    {
        protected TContext Context { get; }
        protected DbSet<TEntity> DbSet { get; }

        private bool _disposed;

        public BaseRepository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return DbSet.Where(predicate).ToList();
            }

            return DbSet.ToList();
        }

        public virtual TEntity GetById(TKey id)
        {
            return DbSet.Find(id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}

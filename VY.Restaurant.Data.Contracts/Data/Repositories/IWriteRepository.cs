using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Restaurant.Data.Contracts.Data.Repositories
{
    public interface IWriteRepository<in TEntity, in TKey> : IDisposable
        where TEntity : class
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        void Remove(IEnumerable<TEntity> entities);

        Task SaveChanges();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VY.Restaurant.Data.Contracts.Data.Repositories
{
    public interface IReadRepository<TEntity, in TKey> : IDisposable where TEntity : class
    {
        TEntity GetById(TKey id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null);
    }
}

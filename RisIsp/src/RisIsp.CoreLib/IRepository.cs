using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.CoreLib
{
    public interface IRepository<TId, TEntity>
    {
        TEntity Add(TEntity item);

        IEnumerable<TEntity> FetchAll();

        TEntity FetchById(TId id);

        TEntity Edit(TEntity item);

        TEntity Remove(TId id);
    }
}

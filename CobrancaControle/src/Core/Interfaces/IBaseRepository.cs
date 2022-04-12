using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
         Task<TEntity> GetOneByAsync();
         Task<IEnumerable<TEntity>> GetAllAsync();
         void Save(TEntity obj, object[] nestedEntities = null);
         void Delete(TEntity obj);
         void Update(TEntity obj,
            DbContext context = null);
         void Update<TProperty>(TEntity obj, params Expression<Func<TEntity, TProperty>>[] ignoreProperties);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext Context;

        public BaseRepository(TContext context)
        {
            Context = context;
        }

        public void Delete(TEntity obj)
        {
            if (obj == null) throw new ArgumentNullException("Ocorreu um erro inesperado. Tente novamente.");
            Context.Set<TEntity>().Remove(obj);
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetOneByAsync()
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync();
        }

        public void Save(TEntity obj, object[] nestedEntities = null)
        {
            if (obj == null) throw new ArgumentNullException("Ocorreu um erro inesperado. Tente novamente.");
            Context.Entry(obj).State = EntityState.Added;

            if (nestedEntities != null && nestedEntities.Length > 0)
                foreach (var nestedEntity in nestedEntities)
                {
                    if (nestedEntity.GetType().IsArray)
                    {
                        var nestedEntityArray = (object[])nestedEntity;
                        foreach (var item in nestedEntityArray)
                        {
                            Context.Entry(item).State = EntityState.Added;
                        }
                    }
                    else
                    {
                        Context.Entry(nestedEntity).State = EntityState.Added;
                    }
                }
        }

        public void Update(TEntity obj, DbContext context = null)
        {
            if (obj == null) throw new ArgumentNullException("Ocorreu um erro inesperado. Tente novamente.");
            (context == null ? Context : context).Entry(obj).State = EntityState.Modified;
        }

        public void Update<TProperty>(TEntity obj, params System.Linq.Expressions.Expression<Func<TEntity, TProperty>>[] ignoreProperties)
        {
            if (obj == null) throw new ArgumentNullException("Ocorreu um erro inesperado. Tente novamente.");

            Context.Entry(obj).State = EntityState.Modified;

            if (ignoreProperties != null)
            {
                foreach (var item in ignoreProperties)
                {
                    Context.Entry(obj).Property(item).IsModified = false;
                }
            }
        }
    }
}
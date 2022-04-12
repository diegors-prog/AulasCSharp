using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Delete(TEntity obj)
        {
            repository.Delete(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public Task<TEntity> GetOneByAsync()
        {
            return repository.GetOneByAsync();
        }

        public void Save(TEntity obj, object[] nestedEntities = null)
        {
            (obj as IBaseEntity).IsValid();
            repository.Save(obj, nestedEntities);
        }

        public void Update(TEntity obj, DbContext context = null)
        {
            (obj as IBaseEntity).IsValid();
            repository.Update(obj, context: context);
        }

        public void Update<TProperty>(TEntity obj, params System.Linq.Expressions.Expression<System.Func<TEntity, TProperty>>[] ignoreProperties)
        {
            repository.Update(obj, ignoreProperties);
        }
    }
}
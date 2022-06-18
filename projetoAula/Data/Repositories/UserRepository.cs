using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext Context;
        public UserRepository(DataContext context)
        {
            this.Context = context;
        }
        
        public bool Delete(int entityId)
        {
            var user = Context.DbSetUser.FirstOrDefault(x => x.Id == entityId);

            if(user == null)
                return false;
            else
            {
                Context.DbSetUser.Remove(user);
                return true;
            }
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await Context.DbSetUser.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int entityId)
        {
            return await Context.DbSetUser
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(User entity)
        {
            Context.DbSetUser.Add(entity);
        }

        public void Update(User entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}